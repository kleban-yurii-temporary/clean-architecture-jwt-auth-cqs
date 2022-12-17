using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Authentication.Commands.RefreshToken
{
    public record RefreshTokenCommand(
        string Token,
        DateTime ExpiryDate);    
}
