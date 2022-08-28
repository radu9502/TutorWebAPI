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
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // POST api/<Authentication>
    
        [HttpPost("Login")]
        public IResult Login(string userName, string password)
        {
          return Authentication.Login(userName, password);
        }
        [HttpPost("Register")]
        public IResult Register(string userName, string password, string email)
        {
          return Authentication.Register(userName, password, email);
            
        }
    }
}
