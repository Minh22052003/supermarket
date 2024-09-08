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
    public class ProductController : ControllerBase
    {
        private readonly DataSuperMartContext _context;
        private readonly IConfiguration _configuration;
        private readonly GoogleDriveService _googleDriveService;
        public ProductController(DataSuperMartContext context, GoogleDriveService googleDriveService, IConfiguration configuration)
        {
            _context = context;
            _googleDriveService = googleDriveService;
            _configuration = configuration;
        }
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = (from p in _context.Products
                            join b in _context.Brands on p.BrandId equals b.BrandId
                            select new
                            {
                                p.ProductId,
                                p.ProductName,
                                Categories = p.ProductCategories.Select(pc => pc.Category.CategoryName).ToList(),
                                p.Price,
                                b.BrandName,
                                p.Description,
                                p.Expiry,
                                p.InventoryQuantity,
                                ProductImages = p.ProductImages.Select(pi => pi.ImageUrl).ToList()
                            }).ToList();
            return Ok(products);
        }
        [HttpGet("product/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = (from p in _context.Products
                           join b in _context.Brands on p.BrandId equals b.BrandId
                           where p.ProductId == id
                           select new
                           {
                               p.ProductId,
                               p.ProductName,
                               Categories = p.ProductCategories.Select(pc => pc.Category.CategoryName).ToList(),
                               p.Price,
                               b.BrandName,
                               p.Description,
                               p.Expiry,
                               p.InventoryQuantity,
                               ProductImages = p.ProductImages.Select(pi => pi.ImageUrl).ToList()
                           }).FirstOrDefault();
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm.");
            }
            return Ok(product);
        }

        

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductDTO product)
        {
            try
            {
                var producttmp = _context.Products.FirstOrDefault(p => p.ProductName == product.ProductName);
                if (producttmp != null)
                {
                    return NotFound("Tên sản phẩm đã tồn tại.");
                }
                var brand = _context.Brands.FirstOrDefault(b =>b.BrandName == product.brandName);
                if(brand == null)
                {
                    return NotFound("Không tìm thấy thương hiệu.");
                }

                var newCategory = new Category
                {
                    CategoryName = product.CategoryName
                };
                var category = _context.Categories.FirstOrDefault(c => c.CategoryName == product.CategoryName);
                if (category == null)
                {
                    _context.Categories.Add(newCategory);
                    _context.SaveChanges();
                }
                else
                {
                    newCategory = category;
                }

                var newProduct = new Product
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    BrandId = brand.BrandId,
                    Description = product.Description,
                    Expiry = product.Expiry,
                    InventoryQuantity = product.InventoryQuantity
                };
                _context.Products.Add(newProduct);
                _context.SaveChanges();

                var newProductCategory = new ProductCategory
                {
                    ProductId = newProduct.ProductId,
                    CategoryId = newCategory.CategoryId
                };
                await AddImageToProductAsync(newProduct.ProductId, product.ImageProduct);
                _context.ProductCategories.Add(newProductCategory);
                _context.SaveChanges();
                return Ok("Thêm sản phẩm thành công.");
            }catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        private async Task<bool> AddImageToProductAsync(int productId, List<IFormFile> images)
        {
            string IDURL = _configuration["IDDrive:IDURLImageProduct"];
            try
            {
                foreach (var image in images)
                {
                    // Lưu file tạm thời lên server để upload lên Google Drive
                    var tempFilePath = Path.GetTempFileName();
                    using (var stream = new FileStream(tempFilePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    // Upload file lên Google Drive
                    var fileId = await _googleDriveService.UploadFileAsync(tempFilePath,IDURL);
                    var link = _googleDriveService.GetFileLink(fileId);
                    var newImage = new ProductImage
                    {
                        ProductId = productId,
                        ImageUrl = link
                    };
                    _context.ProductImages.Add(newImage);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
