using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Models;

namespace TestAPIAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {

        // POST api/<Authentification>
        [HttpPost("Login")]
        public void Login(string userName, string password)
        {
        }
        [HttpPost("Register")]
        public void Register(string userName, string password, string email)
        {
        }
    }
}
