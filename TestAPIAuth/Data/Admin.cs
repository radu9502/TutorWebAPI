using TestAPIAuth.Models;

namespace TestAPIAuth.Data
{
    public static class Admin
    {
        private static DataBaseContext context = new DataBaseContext();
       internal static List<User> GetUsers()
        {
            //var context = new DataBaseContext();
            return context.users.ToList();
        }

        internal static User GetUserById(int id)
        {
           // var context = new DataBaseContext();
            return context.users.FirstOrDefault(x => x.Id == id);
        }

        internal static IResult DeleteUserById(int id)
        {
            //var context = new DataBaseContext();
            User? user = context.users.FirstOrDefault(x => x.Id == id);
            if (user == null) return Results.NotFound("User not found");
            context.users.Remove(user);
            context.SaveChanges();
            return Results.Ok("User deleted");
        }

        internal static List<Category> GetCategories()
        {
            //var context = new DataBaseContext();
            return context.categories.ToList();
        }

        internal static Category GetCategoryById(int id)
        {
           // var context = new DataBaseContext();
            return context.categories.FirstOrDefault(x => x.Id == id);
        }

        internal static IResult DeleteCategoryById(int id)
        {
            //var context = new DataBaseContext();
            Category? cat = context.categories.FirstOrDefault(x => x.Id == id);
            if (cat == null) return Results.NotFound("Category not found");
            context.categories.Remove(cat);
            context.SaveChanges();
            return Results.Ok("Category deleted");
        }

        internal static List<SubCategory> GetSubCategories()
        {
            //var context = new DataBaseContext();
            return context.subCategories.ToList();
        }

        internal static SubCategory GetSubCategoryById(int id)
        {
            //var context = new DataBaseContext();
            return context.subCategories.FirstOrDefault(x => x.Id == id); 
        }

        internal static IResult DeleteSubCategoryById(int id)
        {
           // var context = new DataBaseContext();
            SubCategory? subcat = context.subCategories.FirstOrDefault(x => x.Id == id);
            if (subcat == null) return Results.NotFound("SubCategory not found");
            context.subCategories.Remove(subcat);
            context.SaveChanges();
            return Results.Ok("SubCategory deleted");
        }

        internal static IResult DeleteRequestById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
