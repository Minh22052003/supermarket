using APISuperMarket.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataSuperMartContext _context;
        public UserController(DataSuperMartContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "User")]
        [HttpGet("profile")]
        public IActionResult GetProfileAsync()
        {
            var customerId = User.FindFirst("UserId")?.Value;
            if (customerId == null)
            {
                return NotFound("Không tìm thấy người dùng.");
            }
            var customer = (from c in _context.Customers
                            where c.CustomerId == Convert.ToInt32(customerId)
                            join m in _context.Mail on c.MailId equals m.MailId
                            join g in _context.Genders on c.GenderId equals g.GenderId
                            join p in _context.ProfileImages on c.ProfileImageId equals p.ProfileImageId
                            select new
                            {
                                c.CustomerName,
                                m.EmailAddress,
                                c.BirthDay,
                                g.GenderName,
                                p.ImageUrl
                            }).FirstOrDefault();
            return Ok(customer);
        }
        [HttpPost("editprofile")]
        public IActionResult Editprofie([FromBody] )
        {
            var customerId = User.FindFirst("UserId")?.Value;
        }
    }
}
