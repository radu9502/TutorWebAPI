using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Data.Interfaces;

namespace TestAPIAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthentication _auth;

        public AuthenticationController(IAuthentication auth)
        {
            _auth = auth;
        }


        [HttpPost("Login")]
        public async Task<IResult> Login(string userName, string password)
        {
            return await _auth.Login(userName, password);
        }
        [HttpPost("Register")]
        public async Task<IResult> Register(string userName, string password, string email)
        {
            return await _auth.Register(userName, password, email);
        }
    }
}
