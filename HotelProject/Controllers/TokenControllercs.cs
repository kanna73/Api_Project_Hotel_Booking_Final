using HotelProject.Data;
using HotelProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _config;
        private readonly ProjectContext _projectcontext;

        public TokenController(IConfiguration config, ProjectContext context)
        {
            _config = config;
            _projectcontext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User _userDetails)
        {
            if (_userDetails != null && _userDetails.EmailId != null && _userDetails.Password != null && _userDetails.Roles != null)
            {
                var user = await GetUser(_userDetails.EmailId, _userDetails.Password, _userDetails.Roles);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("UserId", user.UserId.ToString()),
                         new Claim("Email", user.EmailId),
                        new Claim("Password",user.Password),
                        new Claim("Role",user.Roles)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string email, string password, string role)
        {
            return await _projectcontext.Users.FirstOrDefaultAsync(detail => detail.EmailId == email && detail.Password == password && detail.Roles == role);
        }
    }
}
