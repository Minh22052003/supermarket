using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace APISuperMarket.Data
{
    public class GoogleDriveService
    {
        private readonly DriveService _driveService;

        public GoogleDriveService()
        {
            var credential = GoogleCredential.FromFile("C:/Users/alanp/centering-keep-430803-j6-31fa079acfa0.json")
                                             .CreateScoped(DriveService.ScopeConstants.Drive);

            _driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "APISuperMarket"
            });
        }

        public async Task<string> UploadFileAsync(string filePath, string IDURL)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath),
                Parents = new List<string> { IDURL }
            };

            FilesResource.CreateMediaUpload request;
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    request = _driveService.Files.Create(fileMetadata, stream, "application/octet-stream");
                    request.Fields = "id";
                    var uploadResult = await request.UploadAsync();

                    if (uploadResult.Status == UploadStatus.Completed)
                    {
                        var file = request.ResponseBody;
                        if (file != null)
                        {
                            return file.Id;
                        }
                        else
                        {
                            throw new Exception("Failed to get file response from Google Drive.");
                        }
                    }
                    else
                    {
                        throw new Exception($"Upload failed with status: {uploadResult.Status}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ghi lại thông tin lỗi
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public bool DeleteFileAsync(string fileId)
        {
            try
            {
                var request = _driveService.Files.Delete(fileId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }   

        public string GetFileLink(string fileId)
        {
            return $"https://drive.google.com/file/d/{fileId}/view";
        }

        public string GetFileId(string fileLink)
        {
            var fileId = fileLink.Split("/").Last();
            return fileId;
        }

    }
}
