

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly TodoContext _context;

        public TokenController(IConfiguration config, TodoContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserInfo>> Register(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }

            if (await _context.Users.AnyAsync(u => u.Username == userInfo.Username || u.Email == userInfo.Email))
            {
                return BadRequest("Username or email already exists");
            }

            if (userInfo.Password.Length < 6)
            {
                return BadRequest("Password must be at least 6 characters long");
            }

            _context.Users.Add(userInfo);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AuthenticateUser(UserInfo _userData)
        {
            // TODO: make Username optional or check it too
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Username", user.Username),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(1),
                        signingCredentials: signIn);

                    return Ok(value: new JwtSecurityTokenHandler().WriteToken(token));
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

        private async Task<UserInfo> GetUser(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }

}