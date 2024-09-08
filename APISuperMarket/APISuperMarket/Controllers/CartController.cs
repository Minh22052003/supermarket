using APISuperMarket.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DataSuperMartContext _context;
        public CartController(DataSuperMartContext context)
        {
            _context = context;
        }
        [HttpGet("cart")]
        public IActionResult GetCart()
        {
            var customerId = User.FindFirst("UserId")?.Value;
            if (customerId == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }
            var cart = (from c in _context.Carts
                        join p in _context.Products on c.ProductId equals p.ProductId
                        select new
                        {
                            c.CartId,
                            c.ProductId,
                            p.ProductName,
                            p.Price,
                            c.Quantity,
                            Total = p.Price * c.Quantity
                        }).ToList();
            return Ok(cart);
        }
        [HttpPost("cart")]
        public IActionResult AddToCart([FromBody] Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("cart/{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }
            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return Ok();
        }
    }
}
