using System;
using System.Collections.Generic;
using System.Text;

namespace Commom.Security
{
    public class Password
    {
        public static string HashPassword(string password)
        {
            string salt = "asdjpqwa123";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(salt + password);
            System.Security.Cryptography.SHA256Managed PasswordHash = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = PasswordHash.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
