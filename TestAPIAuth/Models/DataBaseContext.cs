using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            var _settings = new DataSettingsManager().LoadSettings();
            var _connection = _settings.ConnectionString.ToString();
            //var connectionString = "Server=localhost\\SQLEXPRESS;Database=TutorAPI;Trusted_Connection=True;";// _configuration.GetConnectionString("dataBase"); 
            optionsBuilder.UseSqlServer(_connection);
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Request> requests { get; set; }

    }

    public class DataSettingsManager
    {
        private const string _dataSettingsFilePath = "appsettings.json";
        public virtual DataSettings LoadSettings()
        {
            var text = File.ReadAllText(_dataSettingsFilePath);
            if (string.IsNullOrEmpty(text))
                return new DataSettings();

            DataSettings settings = JsonConvert.DeserializeObject<DataSettings>(text);
            return settings;
        }
    }
    public class DataSettings
    {
        public string ConnectionString { get; set; }
    }

}
