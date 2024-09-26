using APISuperMarket.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataSuperMarketContext _context;
        public OrderController(DataSuperMarketContext context)
        {
            _context = context;
        }



        [HttpGet("getallorders")]
        public IActionResult GetAllOrders()
        {
            var customerId = User.FindFirst("UserId")?.Value;
            if (customerId == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }
            var orders =( from o in  _context.Orders
                          where o.CustomerId == Convert.ToInt32(customerId)
                          select new
                          {

                          });
            return Ok(orders);
        }
    }
}
