using System;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantManager.Server.Helpper
{
    public class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32; 
        private const int Iterations = 10000;

        // Tạo salt ngẫu nhiên
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Hash mật khẩu với salt
        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Kiểm tra mật khẩu nhập vào có đúng không
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            string hashedInput = HashPassword(password, storedSalt);
            return hashedInput == storedHash;
        }

    }
}
