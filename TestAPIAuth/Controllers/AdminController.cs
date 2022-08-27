using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPIAuth.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpGet("Users")]
        public IEnumerable<string> Users()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("Users/{id}")]
        public string Users(int id)
        {
            return "value";
        }
        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
        }





        [HttpGet("Categories")]
        public IEnumerable<string> Categories()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("Category/{id}")]
        public string Category(int id)
        {
            return "value";
        }

        [HttpDelete("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
        }

        [HttpGet("SubCategories")]
        public IEnumerable<string> SubCategories()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("SubCategories/{id}")]
        public string SubCategories(int id)
        {
            return "value";
        }
        [HttpDelete("DeleteSubCategory/{id}")]
        public void DeleteSubCategory(int id)
        {
        }

        [HttpDelete("DeleteRequest/{id}")]
        public void DeleteRequest(int id)
        {
        }







    }
}
