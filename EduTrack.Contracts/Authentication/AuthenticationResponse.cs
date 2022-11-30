using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Contracts.Authentication
{
    public record AuthenticationResponse (
        Guid Id,
        string? Email,        
        string? FirstName,
        string? LastName,
        string? Role,
        string? Token
    );
}
