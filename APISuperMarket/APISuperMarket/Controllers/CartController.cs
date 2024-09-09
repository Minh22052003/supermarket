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
        private readonly DataSuperMartContext _context;
        public CartController(DataSuperMartContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "User")]
        [HttpGet("getcart")]
        public IActionResult GetCart()
        {
            var customerId = User.FindFirst("UserId")?.Value;
            if (customerId == null)
            {
                return NotFound("Không tìm thấy người dùng.");
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

        [Authorize(Roles = "User")]
        [HttpPost("addtocart")]
        public IActionResult AddToCart([FromBody] CartProductDTO cartProduct)
        {
            try
            {
                if (cartProduct.Action == "Add")
                {
                    var customerId = User.FindFirst("UserId")?.Value;
                    if (customerId == null)
                    {
                        return NotFound("Không tìm thấy người dùng.");
                    }
                    var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == Convert.ToInt32(customerId));
                    if (cart == null)
                    {
                        cart = new Cart
                        {
                            CustomerId = Convert.ToInt32(customerId)
                        };
                        _context.Carts.Add(cart);
                        _context.SaveChanges();
                    }
                    var cartProductInDb = _context.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId && cp.ProductId == cartProduct.ProductId);
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
                    else
                    {
                        cartProductInDb.Quantity += cartProduct.Quantity;
                    }
                    _context.SaveChanges();
                    return Ok("Thêm sản phẩm vào giỏ hàng thành công.");
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [Authorize(Roles= "User")]
        [HttpDelete("deletecartproduct/{productId}")]
        public IActionResult DeleteCartProduct(int productId)
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
                    return NotFound("Không tìm thấy giỏ hàng.");
                }
                var cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId && cp.ProductId == productId);
                if (cartProduct == null)
                {
                    return NotFound("Không tìm thấy sản phẩm trong giỏ hàng.");
                }
                _context.CartProducts.Remove(cartProduct);
                _context.SaveChanges();
                return Ok("Xóa sản phẩm khỏi giỏ hàng thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }



        }

        [Authorize(Roles="User")]
        [HttpPut("updatecartproduct")]
        public IActionResult UpdateCart([FromBody] CartProductDTO cartProduct)
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
                    return NotFound("Không tìm thấy giỏ hàng.");
                }
                var cartProductInDb = _context.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId && cp.ProductId == cartProduct.ProductId);
                if (cartProductInDb == null)
                {
                    return NotFound("Không tìm thấy sản phẩm trong giỏ hàng.");
                }
                cartProductInDb.Quantity = cartProduct.Quantity;
                _context.SaveChanges();
                return Ok("Cập nhật số lượng sản phẩm trong giỏ hàng thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
