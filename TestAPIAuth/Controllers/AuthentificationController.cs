using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestAPIAuth.Models;

namespace TestAPIAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthentificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // POST api/<Authentification>
        [HttpPost("Login")]
        public void Login(string userName, string password)
        {
        }
        [HttpPost("Login2")]
        public IResult Login2(string userName, string password)
        {
            string role = "admin";
            if (!string.IsNullOrEmpty(userName) &&  !string.IsNullOrEmpty(password))
            {
                if (!(userName == "string") || !(password == "string1")) return Results.NotFound("User not found");

                var claims = new[]
                {
            new Claim(ClaimTypes.NameIdentifier, userName),
            new Claim(ClaimTypes.Role, role)
        };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("nksdnkadkndankadnkdaklnadlk"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(tokenString);
            }
            return Results.BadRequest("Invalid user credentials");
        }
        [HttpPost("Register")]
        public void Register(string userName, string password, string email)
        {
        }
    }
}
