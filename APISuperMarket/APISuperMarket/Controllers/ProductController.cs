using APISuperMarket.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                            select new
                            {
                                p.ProductId,
                                p.ProductName,
                                p.Price,
                                p.BrandId,
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

        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromBody] Models.Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Thêm sản phẩm thành công.");
        }
    }
}
