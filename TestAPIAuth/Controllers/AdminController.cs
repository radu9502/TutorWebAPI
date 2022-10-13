using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPIAuth.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("Users")]
        public Task<IResult> Users()
        {
            return Admin.GetUsers();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Users/{id}")]
        public Task<IResult> Users(int id, [FromHeader] string authorization)
        {
            return Admin.GetUserById(id, authorization);
        }
        [HttpDelete("DeleteUser/{id}")]
        public Task<IResult> DeleteUser(int id)
        {
            return Admin.DeleteUserById(id);
        }





        [HttpGet("Categories")]
        public Task<IResult> Categories()
        {
            return Admin.GetCategories();
        }
        [HttpGet("Category/{id}")]
        public Task<IResult> Category(int id)
        {
            return Admin.GetCategoryById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteCategory/{id}")]
        public Task<IResult> DeleteCategory(int id)
        {
            return Admin.DeleteCategoryById(id);
        }

        [HttpGet("SubCategories")]
        public Task<IResult> SubCategories()
        {
            return Admin.GetSubCategories();
        }
        [HttpGet("SubCategories/{id}")]
        public async Task<IResult> SubCategories(int id)
        {
            return await Admin.GetSubCategoryById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteSubCategory/{id}")]
        public async Task<IResult> DeleteSubCategory(int id)
        {
            return await Admin.DeleteSubCategoryById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteRequest/{id}")]
        public async Task<IResult> DeleteRequest(int id)
        {
            return await Admin.DeleteRequestById(id);
        }







    }
}
