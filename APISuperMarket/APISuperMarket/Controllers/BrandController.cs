using APISuperMarket.Data;
using APISuperMarket.DTOs;
using APISuperMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly DataSuperMartContext _context;
        private readonly IConfiguration _configuration;
        private readonly GoogleDriveService _googleDriveService;

        public BrandController(DataSuperMartContext context, IConfiguration configuration, GoogleDriveService googleDriveService)
        {
            _context = context;
            _configuration = configuration;
            _googleDriveService = googleDriveService;
        }
        [HttpPost("addbrand")]
        public IActionResult AddBrand([FromForm] BrandDTO brand)
        {
            try
            {
                var brandtmp = _context.Brands.FirstOrDefault(b => b.BrandName.ToLower() == brand.BrandName.ToLower());
                if (brandtmp != null)
                {
                    return NotFound("Tên thương hiệu đã tồn tại.");
                }
                var newBrand = new Brand
                {
                    BrandName = brand.BrandName,
                    Description = brand.Description,
                    LogoBrandUrl = AddImagetoLogoBrand(brand.Logo_Brand).Result,
                    CreateAt = DateTime.Now

                };
                return Ok(newBrand.BrandName);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        public async Task<string> AddImagetoLogoBrand(IFormFile file)
        {
            string IDURLLogo = _configuration["IDDrive:IDURLImageLogoBrand"];
            try
            {
                // Lưu file tạm thời lên server để upload lên Google Drive
                var tempFilePath = Path.GetTempFileName();
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Upload file lên Google Drive
                var fileId = await _googleDriveService.UploadFileAsync(tempFilePath, IDURLLogo);
                var link = _googleDriveService.GetFileLink(fileId);


                return link;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "";
            }
        }

    }
}
