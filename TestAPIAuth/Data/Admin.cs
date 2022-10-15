using Microsoft.EntityFrameworkCore;
using TestAPIAuth.Data.Interfaces;
using TestAPIAuth.Models;
using static TestAPIAuth.Utils.JwtInfo;

namespace TestAPIAuth.Data
{
    public class Admin : IAdmin
    {
        private readonly IDataBaseContext _context;


        public Admin(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetUsers()
        {

            List<User>? _users = await _context.users.ToListAsync();
            return (_users.Count == 0) ?
                Results.NotFound() :
                Results.Ok(_users);
        }

        public async Task<IResult> GetUserById(int id, string authorization)
        {
            
            if ((IsCurrentUser(authorization, id) || IsAdmin(authorization)) == false) return Results.BadRequest("Restricted");

            User? _user = await _context.users.FirstOrDefaultAsync(x => x.Id == id);
            return (_user == null) ?
                Results.NotFound() :
                Results.Ok(_user);
        }

        public async Task<IResult> DeleteUserById(int id)
        {

            User? user = await _context.users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return Results.NotFound("User not found");
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return Results.Ok("User deleted");
        }

        public async Task<IResult> GetCategories()
        {
            using var context = new DataBaseContext();
            List<Category>? _categories = await _context.categories.ToListAsync();
            return (_categories.Count > 0) ?
                Results.Ok(_categories) :
                Results.NotFound();
        }

        public async Task<IResult> GetCategoryById(int id)
        {

            Category? category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            return (category != null) ?
                 Results.Ok(category) :
                 Results.NotFound(id);
        }

        public async Task<IResult> DeleteCategoryById(int id)
        {

            Category? cat = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (cat == null) return Results.NotFound("Category not found");
            _context.categories.Remove(cat);
            await _context.SaveChangesAsync();
            return Results.Ok("Category deleted");
        }

        public async Task<IResult> GetSubCategories()
        {

            List<SubCategory>? subCategories = await _context.subCategories.ToListAsync();
            return (subCategories.Count > 0) ?
                Results.Ok(subCategories) :
                Results.NotFound();
        }

        public async Task<IResult> GetSubCategoryById(int id)
        {

            SubCategory? subCategory = await _context.subCategories.FirstOrDefaultAsync(x => x.Id == id);
            return (subCategory != null) ?
                Results.Ok(subCategory) :
                Results.NotFound();
        }

        public async Task<IResult> DeleteSubCategoryById(int id)
        {
            SubCategory? subcat = await _context.subCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (subcat == null) return Results.NotFound("SubCategory not found");
            _context.subCategories.Remove(subcat);
            await _context.SaveChangesAsync();
            return Results.Ok("SubCategory deleted");
        }

        public async Task<IResult> DeleteRequestById(int id)
        {
            Request? request = await _context.requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request == null) return Results.NotFound("Request not found");
            _context.requests.Remove(request);
            await _context.SaveChangesAsync();
            return Results.Ok("Request deleted");
        }
    }
}
