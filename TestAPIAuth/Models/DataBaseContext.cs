//global using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
/*using Microsoft.EntityFrameworkCore;*/

namespace TestAPIAuth.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DataBaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=TutorAPI;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Request> requests { get; set; }

    }
}
