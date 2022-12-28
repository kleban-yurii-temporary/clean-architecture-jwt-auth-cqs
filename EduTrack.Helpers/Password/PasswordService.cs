using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace EduTrack.Helpers.Password
{
    public class PasswordService 
    {
        public static (string, byte[]) CreatePasswordHash(string password)
        {
            var passwordSalt = RandomNumberGenerator.GetBytes(128 / 8);

            var passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password!,
                            salt: passwordSalt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));

            return (passwordHash, passwordSalt);
        }

        public static bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password!,
                            salt: passwordSalt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));

                return computeHash == passwordHash;
            }
        }

        /*public (byte[], byte[]) CreatePasswordHash(string password)
        {
            using(var hmac = new HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return (passwordHash, passwordSalt);
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash == passwordHash;               
            }
        }*/
    }
}
