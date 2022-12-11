using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Authentication
{
    public interface IPasswordHashGenerator
    {
        (string, byte[])  CreatePasswordHash(string password);

       bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt);

        /* (byte[], byte[]) CreatePasswordHash(string password);

         bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);*/

    }
}
