using APISuperMarket.Data;
using APISuperMarket.DTOs;
using APISuperMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly DataSuperMarketContext _context;
        private readonly IConfiguration _configuration;
        private readonly GoogleDriveService _googleDriveService;
        public BrandController(DataSuperMarketContext context, GoogleDriveService googleDriveService, IConfiguration configuration)
        {
            _context = context;
            _googleDriveService = googleDriveService;
            _configuration = configuration;
        }

        [HttpGet("getallbrand")]
        public IActionResult GetAllBrand()
        {
            try
            {
                var brands = _context.Brands.ToList();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
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
                _context.Brands.Add(newBrand);
                _context.SaveChanges();
                return Ok(newBrand.BrandName);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("updatebrand")]
        public IActionResult UpdateBrand([FromForm] BrandDTO brand)
        {
            try
            {
                var brandtmp = _context.Brands.FirstOrDefault(b => b.BrandName.ToLower() == brand.BrandName.ToLower());
                if (brandtmp == null)
                {
                    return NotFound("Tên thương hiệu không tồn tại.");
                }

                brandtmp.Description = brand.Description;
                var fileid = _googleDriveService.GetFileId(brandtmp.LogoBrandUrl);
                bool check =_googleDriveService.DeleteFileAsync(fileid);
                if (!check)
                {
                    return NotFound("Xóa ảnh không thành công");
                }
                brandtmp.LogoBrandUrl = AddImagetoLogoBrand(brand.Logo_Brand).Result;
                brandtmp.UpdateAt = DateTime.Now;

                _context.SaveChanges();
                return Ok("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("deletebrand")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                var brand = _context.Brands.FirstOrDefault(b => b.BrandId == id);
                if (brand == null)
                {
                    return NotFound("Thương hiệu không tồn tại.");
                }
                var fileid = _googleDriveService.GetFileId(brand.LogoBrandUrl);
                bool check = _googleDriveService.DeleteFileAsync(fileid);
                if (!check)
                {
                    return NotFound("Xóa ảnh không thành công");
                }
                _context.Brands.Remove(brand);
                _context.SaveChanges();
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }


        private async Task<string> AddImagetoLogoBrand(IFormFile file)
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
