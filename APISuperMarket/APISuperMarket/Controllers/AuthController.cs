using APISuperMarket.Data;
using APISuperMarket.DTOs;
using APISuperMarket.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataSuperMartContext _context;

        public AuthController(IConfiguration configuration, DataSuperMartContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto user)
        {
            var account = await _context.AccCustomers
            .Where(a => a.UserName == user.User_Name && a.UserName == user.User_Name)
            .Select(a => a.CustomerId)
            .FirstOrDefaultAsync();

            if (account == 0)
            {
                return NotFound("Không tìm thấy tài khoản người dùng.");
            }

            if (account != null)
            {
                var roles = await _context.CustomerRoles
                .Where(cr => cr.CustomerId == account)
                .Select(cr => cr.Role.RoleName)
                .ToListAsync();
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.User_Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId", account.ToString())
                };

                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);


                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                // Tạo cookie chứa JWT
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(30)
                };

                Response.Cookies.Append("AuthToken", jwtToken, cookieOptions);
                return Ok("Đăng nhập thành công");
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
        {
            List<string> listgmail = _context.Mail.Select(a => a.EmailAddress).ToList();
            if (registerRequest.IsGoogleRegistrantion == false)
            {
                var accuser = _context.AccCustomers.FirstOrDefault(a => a.UserName == registerRequest.UserName);
                if (accuser != null)
                {
                    return NotFound("Tài khoản đã tồn tại trong hệ thống");
                }
                foreach (var gmail in listgmail)
                {
                    if (gmail == registerRequest.Gmail)
                    {
                        return NotFound("Gmail đã tồn tại trong hệ thống");
                    }
                }
                var newMail = new Mail
                {
                    EmailAddress = registerRequest.Gmail
                };
                _context.Mail.Add(newMail);
                await _context.SaveChangesAsync();
                var newUser = new Customer
                {
                    MailId = newMail.MailId,
                };
                _context.Customers.Add(newUser);
                await _context.SaveChangesAsync();
                var newAccUser = new AccCustomer
                {
                    CustomerId = newUser.CustomerId, 
                    UserName = registerRequest.UserName,
                    HashPass = registerRequest.Password,
                    AuthProvider = null,
                    DateCreation = DateTime.UtcNow,
                    StatusAccId = 7
                };
                _context.AccCustomers.Add(newAccUser);
                await _context.SaveChangesAsync();
                var customerRole = new CustomerRole
                {
                    CustomerId = newUser.CustomerId,
                    RoleId = 2
                };
                _context.CustomerRoles.Add(customerRole);
                await _context.SaveChangesAsync();

                return Ok("Đăng kí tài khoản thành công");
                
            }
            else
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(registerRequest.GoogleRegistrantToken);

                if (payload != null)
                {
                    var googleUserId = payload.Subject;

                    var accUser = _context.AccCustomers.FirstOrDefault(a => a.ProviderId == googleUserId);
                    if (accUser != null)
                    {
                        return NotFound("Tài khoản đã được đăng kí trước đó");
                    }
                    foreach (var gmail in listgmail)
                    {
                        if (gmail == registerRequest.Gmail)
                        {
                            return NotFound("Gmail đã tồn tại trong hệ thống");
                        }
                    }
                    var newMail = new Mail
                    {
                        EmailAddress = registerRequest.Gmail
                    };
                    _context.Mail.Add(newMail);
                    await _context.SaveChangesAsync();
                    var newUser = new Customer
                    {
                        MailId = newMail.MailId,
                    };
                    _context.Customers.Add(newUser);
                    await _context.SaveChangesAsync();
                    var newAccCustomer = new AccCustomer
                    {
                        CustomerId = newUser.CustomerId,
                        ProviderId = googleUserId,
                        AuthProvider = "Google",
                        DateCreation = DateTime.UtcNow,
                        StatusAccId = 1
                    };

                    _context.AccCustomers.Add(newAccCustomer);
                    await _context.SaveChangesAsync();

                    var customerRole = new CustomerRole
                    {
                        CustomerId = newUser.CustomerId,
                        RoleId = 2
                    };
                    _context.CustomerRoles.Add(customerRole);
                    await _context.SaveChangesAsync();

                    return Ok("Đăng kí tài khoản thành công");
                }
                else
                {
                    return BadRequest("Đăng kí bằng Google không thành công");
                }
            }
        }


    }
}
