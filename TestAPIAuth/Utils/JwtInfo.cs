using System.IdentityModel.Tokens.Jwt;
using TestAPIAuth.Models;

namespace TestAPIAuth.Utils
{
    public static class JwtInfo

    {

        public static string GetJwtRole(string authorization)
        {
            var jwtSecurityToken = GetJwtInfo(authorization);
            string role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;

            return role;

        }
        public static string GetJwtId(string authorization)
        {
            var jwtSecurityToken = GetJwtInfo(authorization);
            string id = jwtSecurityToken.Claims.First(claim => claim.Type == "id").Value;

            return id;

        }

        public static string GetJwtName(string authorization)
        {
            var jwtSecurityToken = GetJwtInfo(authorization);
            string userName = jwtSecurityToken.Claims.First(claim => claim.Type == "name").Value;

            return userName;
        }

        public static JwtSecurityToken GetJwtInfo(string authorization)
        {
            string[] token = authorization.Split(" ");
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token[1]);
            return jwtSecurityToken;

        }

        public static bool IsOwner(string authorization, Request request)
        {

            string HeaderId = JwtInfo.GetJwtId(authorization);
            if (HeaderId != request.RequestorId.ToString())
            {
                Console.WriteLine("Request owner not the same as the requestor");
                return false;
            }

            return true;
        }
        public static bool IsAdmin(string authorization, Request request)
        {

            string HeaderRole = JwtInfo.GetJwtRole(authorization);
            if (HeaderRole != "Admin")
            {
                Console.WriteLine("Request is not an admin");
                return false;
            }
            return true;
        }
    }
}
