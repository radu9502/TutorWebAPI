using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestAPIAuth.Models;
using Microsoft.EntityFrameworkCore;
namespace TestAPIAuth.Data
{
    public static class Authentication
    {
        private static DataBaseContext? _context = new DataBaseContext();

        public static async Task<IResult> Register(string userName, string password, string email)
        {
           // var _context = new DataBaseContext();
            User user = new User(userName, password, email);
            if (await _context.users.FirstOrDefaultAsync(x => x.UserName == userName) != null) return Results.BadRequest("User already exists");
            if (await _context.users.FirstOrDefaultAsync(x => x.Email == email) != null) return Results.BadRequest("Email already exists");
            Console.WriteLine(user.Role.ToString());
            _context.users.AddAsync(user);
            _context.SaveChangesAsync();
            return Results.Ok("Success");
        }

        public static async Task<IResult> Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                //var _context = new DataBaseContext();
                User? user = await _context.users.FirstOrDefaultAsync(x => x.UserName == userName);
                if (user == null || user.Password != password) return Results.NotFound("Incorrect user or password");
                

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userName),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Aud,"https://localhost:7260/api"),
                    new Claim(JwtRegisteredClaimNames.Iss,"https://localhost:7260/api")
                 };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("MIIBCgKCAQEAsXoUruE3QybI3ygaARBUl0e663kxvylbSqlLBPf"));

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
