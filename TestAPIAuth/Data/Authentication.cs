using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPIAuth.Data.Interfaces;
using TestAPIAuth.Models;
using static TestAPIAuth.Utils.PasswordManager;

namespace TestAPIAuth.Data
{
    public class Authentication : IAuthentication
    {
        private readonly IDataBaseContext _context;

        public Authentication(IDataBaseContext context)
        {
            _context = context;
        }



        public async Task<IResult> Register(string userName, string password, string email)
        {

            User user = new User(userName, password, email);
            if (await _context.users.FirstOrDefaultAsync(x => x.UserName == userName) != null) return Results.BadRequest("User already exists");
            if (await _context.users.FirstOrDefaultAsync(x => x.Email == email) != null) return Results.BadRequest("Email already exists");

            string randomGeneratedSalt = CreateSalt();
            string hashedBase64StringPassword = GetHash(password, randomGeneratedSalt);


            user.Password = hashedBase64StringPassword;
            user.Salt = randomGeneratedSalt;
            Console.WriteLine(user.Role.ToString());
            _context.users.AddAsync(user);
            _context.SaveChangesAsync();
            return Results.Ok("Success");
        }

        public async Task<IResult> Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {

                User? user = await _context.users.FirstOrDefaultAsync(x => x.UserName == userName);
                bool isPasswordCorrect = CompareHashedPasswords(password, user.Password, user.Salt);
                if (user == null || !isPasswordCorrect) return Results.NotFound("Incorrect user or password");


                var claims = new[]
                {
                    new Claim("name", user.UserName),
                    new Claim("id", user.Id.ToString()),
                    new Claim("role", user.Role.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Aud,"https://localhost:7260/api"),
                    new Claim(JwtRegisteredClaimNames.Iss,"https://localhost:7260/api")
                 };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIIBCgKCAQEAsXoUruE3QybI3ygaARBUl0e663kxvylbSqlLBPf"));

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
