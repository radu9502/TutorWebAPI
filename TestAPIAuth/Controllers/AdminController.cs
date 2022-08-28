using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Data;
using TestAPIAuth.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPIAuth.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpGet("Users")]
        public List<User> Users()
        {
            return Admin.GetUsers();
        }

        [HttpGet("Users/{id}")]
        public User Users(int id)
        {
            return Admin.GetUserById(id);
        }
        [HttpDelete("DeleteUser/{id}")]
        public IResult DeleteUser(int id)
        {
           return Admin.DeleteUserById(id);
        }





        [HttpGet("Categories")]
        public List<Category> Categories()
        {
            return Admin.GetCategories();
        }
        [HttpGet("Category/{id}")]
        public Category Category(int id)
        {
            return Admin.GetCategoryById(id);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IResult DeleteCategory(int id)
        {
            return Admin.DeleteCategoryById(id);
        }

        [HttpGet("SubCategories")]
        public List<SubCategory> SubCategories()
        {
            return Admin.GetSubCategories();
        }
        [HttpGet("SubCategories/{id}")]
        public SubCategory SubCategories(int id)
        {
            return Admin.GetSubCategoryById(id);
        }
        [HttpDelete("DeleteSubCategory/{id}")]
        public IResult DeleteSubCategory(int id)
        {
            return Admin.DeleteSubCategoryById(id);
        }

        [HttpDelete("DeleteRequest/{id}")]
        public IResult DeleteRequest(int id)
        {
           return Admin.DeleteRequestById(id);
        }







    }
}
