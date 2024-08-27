using APISuperMarket.Data;
using APISuperMarket.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                return NotFound("User not found or password is incorrect.");
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

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }
    }
}
