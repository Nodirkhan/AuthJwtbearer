using AuthJwtbearer.Inteface;
using AuthJwtbearer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthJwtbearer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _user;
        private readonly IConfiguration _config;

        public UserController(IUserRepository user, IConfiguration config )
        {
            _user = user;
            _config = config;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("No Data");
            }
            var user = await _user.LoginAsync(model.UserName, model.Password);
            if(user == null) return NotFound();
            var key = Encoding.ASCII.GetBytes(_config["JWT:SecretKey"]);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Name, user.LastName),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("Username", user.UserName)
                    }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securiyToken = new JwtSecurityTokenHandler().CreateToken(tokenDescription);
            var token =  new JwtSecurityTokenHandler().WriteToken(securiyToken);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            HttpContext.Session.SetString("JWToken", token);
            return Ok(token);
            
        }
    }
}
