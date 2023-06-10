using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Milk_Production.DAL
{
    public class passwordHash
    {
        public static string passHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hashString;
            }

        }
    }
}