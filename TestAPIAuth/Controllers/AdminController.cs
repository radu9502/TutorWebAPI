using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAPIAuth.Data.Interfaces;


namespace TestAPIAuth.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin admin;

        public AdminController(IAdmin _admin)
        {
            admin = _admin;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("Users")]
        public async Task<IResult> Users()
        {
            return await admin.GetUsers();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Users/{id}")]
        public async Task<IResult> Users(int id, [FromHeader] string authorization)
        {
            return await admin.GetUserById(id, authorization);
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IResult> DeleteUser(int id)
        {
            return await admin.DeleteUserById(id);
        }





        [HttpGet("Categories")]
        public async Task<IResult> Categories()
        {
            return await admin.GetCategories();
        }
        [HttpGet("Category/{id}")]
        public async Task<IResult> Category(int id)
        {
            return await admin.GetCategoryById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IResult> DeleteCategory(int id)
        {
            return await admin.DeleteCategoryById(id);
        }

        [HttpGet("SubCategories")]
        public async Task<IResult> SubCategories()
        {
            return await admin.GetSubCategories();
        }
        [HttpGet("SubCategories/{id}")]
        public async Task<IResult> SubCategories(int id)
        {
            return await admin.GetSubCategoryById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteSubCategory/{id}")]
        public async Task<IResult> DeleteSubCategory(int id)
        {
            return await admin.DeleteSubCategoryById(id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("DeleteRequest/{id}")]
        public async Task<IResult> DeleteRequest(int id)
        {
            return await admin.DeleteRequestById(id);
        }







    }
}
