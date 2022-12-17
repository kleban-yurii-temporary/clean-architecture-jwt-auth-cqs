using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Authentication
{
    public record AuthenticationResponseDto (
        string? Token,
        string? RefreshToken
    );
}
