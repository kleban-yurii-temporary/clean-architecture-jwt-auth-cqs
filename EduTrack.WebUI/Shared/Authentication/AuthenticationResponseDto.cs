using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Authentication
{
    public record AuthenticationResponse(
        string? AccessToken,
        string? RefreshToken
    );

    public record RefreshTokenRequest(
        string? AccessToken, 
        string? RefreshToken);
}
