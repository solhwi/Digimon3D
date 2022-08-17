using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public class HashSalt
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }

    public class HashHelper
    {
        public static int Iteration = 9999;
        public static HashSalt Hash(string HashTarget)
        {
            var SaltBytes = new byte[256];
            var Provider = new RNGCryptoServiceProvider();
            Provider.GetNonZeroBytes(SaltBytes);
            var GenSalt = Convert.ToBase64String(SaltBytes);

            var Rfc2898DeriveBytes = new Rfc2898DeriveBytes(HashTarget, SaltBytes, Iteration);
            var HashedPassword = Convert.ToBase64String(Rfc2898DeriveBytes.GetBytes(256));

            return new HashSalt { Hash = HashedPassword, Salt = GenSalt };
        }

        public static bool Verify(string VerifyTarget, HashSalt InHashSalt)
        {
            var SaltBytes = Convert.FromBase64String(InHashSalt.Salt); 
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(VerifyTarget, SaltBytes, Iteration);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == InHashSalt.Hash;
        }
    }
}
