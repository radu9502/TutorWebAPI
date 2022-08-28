using TestAPIAuth.Models;
namespace TestAPIAuth.Data
{
    public static class Authentification
    {
        public static bool Register(string userName, string password, string email)
        {
            var context = new DataBaseContext();
            User user = new User(userName, password, email);
            if (context.users.FirstOrDefault(x => x.UserName == userName) != null) return true;
            context.users.Add(user);
            context.SaveChanges();
            return false;
        }
    }
}
