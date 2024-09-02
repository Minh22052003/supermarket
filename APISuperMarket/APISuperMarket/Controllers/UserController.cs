using APISuperMarket.Data;
using APISuperMarket.DTOs;
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
                            join m in _context.Mail on c.MailId equals m.MailId into mailGroup
                            from m in mailGroup.DefaultIfEmpty()
                            join g in _context.Genders on c.GenderId equals g.GenderId into genderGroup
                            from g in genderGroup.DefaultIfEmpty()
                            join p in _context.ProfileImages on c.ProfileImageId equals p.ProfileImageId into profileGroup
                            from p in profileGroup.DefaultIfEmpty()
                            where c.CustomerId == Convert.ToInt32(customerId)
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
        [HttpPut("editprofile")]
        public IActionResult Editprofie([FromBody] ProfileUserDTO profileUserDTO)
        {
            try
            {
                var customerId = User.FindFirst("UserId")?.Value;
                if (customerId == null)
                {
                    return NotFound("Không tìm thấy người dùng.");
                }
                else
                {
                    var customer = _context.Customers.Find(Convert.ToInt32(customerId));
                    if (customer == null)
                    {
                        return NotFound("Không tìm thấy người dùng.");
                    }
                    customer.CustomerName = profileUserDTO.CustomerName;
                    customer.BirthDay = profileUserDTO.BirthDay;

                    var gender = _context.Genders.Find(profileUserDTO.GenderName);
                    customer.GenderId = gender.GenderId;

                    var profileImage = _context.ProfileImages.Find(customer.ProfileImageId);
                    customer.ProfileImageId = profileImage.ProfileImageId;

                    _context.SaveChanges();
                    return Ok("Cập nhật thông tin thành công.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
