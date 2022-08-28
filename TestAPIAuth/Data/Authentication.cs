using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestAPIAuth.Models;
namespace TestAPIAuth.Data
{
    public static class Authentication
    {
        public static IResult Register(string userName, string password, string email)
        {
            var context = new DataBaseContext();
            User user = new User(userName, password, email);
            if (context.users.FirstOrDefault(x => x.UserName == userName) != null) return Results.BadRequest("User already exists");
            if (context.users.FirstOrDefault(x => x.Email == email) != null) return Results.BadRequest("Email already exists");
            context.users.Add(user);
            context.SaveChanges();
            return Results.Ok("Success");
        }

        public static IResult Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var context = new DataBaseContext();
                User? user = context.users.FirstOrDefault(x => x.UserName == userName);
                if (user == null || user.Password != password) return Results.NotFound("Incorrect user or password");
                

                var claims = new[]
                {
            new Claim(ClaimTypes.NameIdentifier, userName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
                 };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("nksdnkadkndankadnkdaklnadlk"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(tokenString);
            }
            return Results.BadRequest("Invalid user credentials");
        }
    }
}
