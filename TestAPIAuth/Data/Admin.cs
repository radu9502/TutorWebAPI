using Microsoft.EntityFrameworkCore;
using TestAPIAuth.Models;

namespace TestAPIAuth.Data
{
    public static class Admin
    {
        //private static DataBaseContext context = new DataBaseContext();
        internal static async Task<IResult> GetUsers()
        {
            using var context = new DataBaseContext();
            List<User>? _users = await context.users.ToListAsync();
            return (_users.Count == 0) ?
                Results.NotFound() :
                Results.Ok(_users);
        }

        internal static async Task<IResult> GetUserById(int id)
        {
            using var context = new DataBaseContext();
            User? _user = await context.users.FirstOrDefaultAsync(x => x.Id == id);
            return (_user == null) ?
                Results.NotFound() :
                Results.Ok(_user);
        }

        internal static async Task<IResult> DeleteUserById(int id)
        {
            using var context = new DataBaseContext();
            User? user = await context.users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return Results.NotFound("User not found");
            context.users.Remove(user);
            await context.SaveChangesAsync();
            return Results.Ok("User deleted");
        }

        internal static async Task<IResult> GetCategories()
        {
            using var context = new DataBaseContext();
            List<Category>? _categories = await context.categories.ToListAsync();
            return (_categories.Count > 0) ?
                Results.Ok(_categories) :
                Results.NotFound();
        }

        internal static async Task<IResult> GetCategoryById(int id)
        {
            using var context = new DataBaseContext();
            Category? category = await context.categories.FirstOrDefaultAsync(x => x.Id == id);
            return (category != null) ?
                 Results.Ok(category) :
                 Results.NotFound(id);
        }

        internal static async Task<IResult> DeleteCategoryById(int id)
        {
            using var context = new DataBaseContext();
            Category? cat = await context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (cat == null) return Results.NotFound("Category not found");
            context.categories.Remove(cat);
            await context.SaveChangesAsync();
            return Results.Ok("Category deleted");
        }

        internal static async Task<IResult> GetSubCategories()
        {
            using var context = new DataBaseContext();
            List<SubCategory>? subCategories = await context.subCategories.ToListAsync();
            return (subCategories.Count > 0) ?
                Results.Ok(subCategories) :
                Results.NotFound();
        }

        internal static async Task<IResult> GetSubCategoryById(int id)
        {
            using var context = new DataBaseContext();
            SubCategory? subCategory = await context.subCategories.FirstOrDefaultAsync(x => x.Id == id);
            return (subCategory != null) ?
                Results.Ok(subCategory) :
                Results.NotFound();
        }

        internal static async Task<IResult> DeleteSubCategoryById(int id)
        {
            using var context = new DataBaseContext();
            SubCategory? subcat = await context.subCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (subcat == null) return Results.NotFound("SubCategory not found");
            context.subCategories.Remove(subcat);
            await context.SaveChangesAsync();
            return Results.Ok("SubCategory deleted");
        }

        internal static async Task<IResult> DeleteRequestById(int id)
        {
            using var context = new DataBaseContext();
            Request? request = await context.requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request == null) return Results.NotFound("Request not found");
            context.requests.Remove(request);
            await context.SaveChangesAsync();
            return Results.Ok("Request deleted");
        }
    }
}
