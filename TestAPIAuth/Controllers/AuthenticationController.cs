using Microsoft.AspNetCore.Mvc;
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
        public async Task<IResult> Login(string userName, string password)
        {
            return await Authentication.Login(userName, password);
        }
        [HttpPost("Register")]
        public async Task<IResult> Register(string userName, string password, string email)
        {
            return await Authentication.Register(userName, password, email);
        }
    }
}
