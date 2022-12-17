using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Authentication
{
    public record RefreshTokenDto(
        string Token, 
        string RefreshToken);
    
}
