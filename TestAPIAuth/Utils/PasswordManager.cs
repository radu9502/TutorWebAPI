using System.Security.Cryptography;
using System.Text;

namespace TestAPIAuth.Utils
{
    public static class PasswordManager
    {
        public static string CreateSalt()
        {
            byte[] salt;
            //Generate a cryptographic random number.
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return Convert.ToBase64String(salt);
        }

        public static string GetHash(string PlainPassword, string Salt)
        {
            byte[] byteArray = Encoding.Unicode.GetBytes(String.Concat(Salt, PlainPassword));
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashBytes = sha256.ComputeHash(byteArray);
            byte[] hashedBytes = sha256.ComputeHash(byteArray);
            return Convert.ToBase64String(hashedBytes);
        }

        public static bool CompareHashedPasswords(string userInputPasword, string existingHashedBase64StringPassword, string salt)
        {
            string UserInputtedHashedPassword = GetHash(userInputPasword, salt);

            return UserInputtedHashedPassword == existingHashedBase64StringPassword;
        }
    }
}
