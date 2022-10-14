using Microsoft.EntityFrameworkCore;

namespace TestAPIAuth.Models
{
    public interface IDataBaseContext
    {
        DbSet<Category> categories { get; set; }
        DbSet<Message> messages { get; set; }
        DbSet<Request> requests { get; set; }
        DbSet<SubCategory> subCategories { get; set; }
        DbSet<User> users { get; set; }

        Task SaveChangesAsync();

    }
}