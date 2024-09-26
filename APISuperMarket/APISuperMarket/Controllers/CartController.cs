using APISuperMarket.Data;
using APISuperMarket.DTOs;
using APISuperMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DataSuperMarketContext _context;
        public CartController(DataSuperMarketContext context)
        {
            _context = context;
        }

        [HttpGet("getcart")]
        public IActionResult GetCart()
        {
            try
            {
                var customerId = User.FindFirst("UserId")?.Value;
                if (customerId == null)
                {
                    return NotFound("Không tìm thấy người dùng.");
                }
                var cartcheck = _context.Carts.FirstOrDefault(c => c.CustomerId == Convert.ToInt32(customerId));
                if (cartcheck == null)
                {
                    return NotFound("Không tìm thấy giỏ hàng.");
                }
                var cart = (from c in _context.Carts
                            join cp in _context.CartProducts on c.CartId equals cp.CartId
                            join p in _context.Products on cp.ProductId equals p.ProductId
                            where c.CustomerId == Convert.ToInt32(customerId)
                            select new
                            {
                                c.CartId,
                                p.ProductId,
                                p.ProductName,
                                p.Price,
                                cp.Quantity
                            }).ToList();
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        [HttpPost("editcart")]
        public IActionResult EditCart([FromBody] CartProductDTO cartProduct)
        {
            try
            {
                
                var customerId = User.FindFirst("UserId")?.Value;
                if (customerId == null)
                {
                    return NotFound("Không tìm thấy người dùng.");
                }
                var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == Convert.ToInt32(customerId));
                if (cart == null)
                {
                    return NotFound("Lỗi không tìm thấy giỏ hàng.");
                }
                var cartProductInDb = _context.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId && cp.ProductId == cartProduct.ProductId);
                var product = _context.Products.Find(cartProduct.ProductId);

                //TH1 chưa có sản phẩm trong giỏ hàng
                if (cartProductInDb == null)
                {
                    cartProductInDb = new CartProduct
                    {
                        CartId = cart.CartId,
                        ProductId = cartProduct.ProductId,
                        Quantity = cartProduct.Quantity
                    };
                    _context.CartProducts.Add(cartProductInDb);
                    _context.SaveChanges();
                }
                //TH2 đã có sản phẩm trong giỏ hàng
                if (cartProduct.Action == "Increase" && product.InventoryQuantity >= (cartProduct.Quantity + cartProductInDb.Quantity))
                {
                    cartProductInDb.Quantity += cartProduct.Quantity;
                }
                else if (cartProduct.Action == "Increase" && product.InventoryQuantity < (cartProduct.Quantity + cartProductInDb.Quantity))
                {
                    return NotFound("Bạn đã thêm vượt quá số sản phẩm trong kho.");
                }

                if (cartProduct.Action == "Decrease" && cartProductInDb.Quantity >= cartProduct.Quantity)
                {
                    cartProductInDb.Quantity -= cartProduct.Quantity;
                }
                else if (cartProduct.Action == "Decrease" && cartProductInDb.Quantity < cartProduct.Quantity)
                {
                    return NotFound("Bạn đã xóa số sản phẩm vượt quá số lượng trong giỏ hàng");
                }
                _context.SaveChanges();
                return Ok("Cập nhật giỏ hàng thành công.");
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        
        
    }
}
