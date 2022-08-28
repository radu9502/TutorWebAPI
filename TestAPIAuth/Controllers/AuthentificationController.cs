using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestAPIAuth.Models;
using TestAPIAuth.Data;


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
        public IResult Login(string userName, string password)
        {
          return Authentification.Login(userName, password);
        }
        [HttpPost("Register")]
        public IResult Register(string userName, string password, string email)
        {
          return Authentification.Register(userName, password, email);
            
        }
    }
}
