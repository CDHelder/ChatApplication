using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Business
{
    public class HashingService
    {
        public string CreatePasswordHash(string password, string salt)
        {
            var byteSalt = Convert.FromBase64String(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, byteSalt, 100000);
            return Convert.ToBase64String(pbkdf2.GetBytes(20));
        }

        public string CreateSalt()
        {
            byte[] pass = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(pass);
            return Convert.ToBase64String(pass);
        }
    }
}
