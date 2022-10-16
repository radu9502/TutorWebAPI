using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TestAPIAuth.Models
{

    public class DataBaseContext : DbContext, IDataBaseContext
    {
        private readonly IConfiguration _configuration;
        public DataBaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DataBaseContext() { }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            
            var _connection = _configuration["ConnectionString2:DataBase"];
            optionsBuilder.UseSqlServer(_connection);
         
        }

        public Task SaveChangesAsync() => base.SaveChangesAsync();





        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Request> requests { get; set; }


    }


}
