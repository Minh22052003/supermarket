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
        public ProductController(DataSuperMartContext context)
        {
            _context = context;
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
                                p.InventoryQuantity
                            }).ToList();
            return Ok(products);
        }
        [HttpGet("product/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = (from p in _context.Products
                           where p.ProductId == id
                           select new
                           {
                               p.ProductId,
                               p.ProductName,
                               p.Price,
                               p.BrandId,
                               p.Description,
                               p.Expiry,
                               p.InventoryQuantity
                           }).FirstOrDefault();
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm.");
            }
            return Ok(product);
        }

        [HttpPost("addbrand")]
        public IActionResult AddBrand([FromBody] BrandDTO brand)
        {
            try
            {
                var brandtmp = _context.Brands.FirstOrDefault(b => b.BrandName == brand.BrandName);
                if (brandtmp != null)
                {
                    return NotFound("Tên thương hiệu đã tồn tại.");
                }
                var newBrand = new Brand
                {
                    BrandName = brand.BrandName,
                    Description = brand.Description,
                    NumberOfProducts = brand.NumberOfProducts
                };
                return Ok(newBrand.BrandName);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromBody] ProductDTO product)
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
                    //_context.Categories.Add(newCategory);
                    //_context.SaveChanges();
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
                _context.ProductCategories.Add(newProductCategory);
                _context.SaveChanges();
                return Ok("Thêm sản phẩm thành công.");
            }catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
