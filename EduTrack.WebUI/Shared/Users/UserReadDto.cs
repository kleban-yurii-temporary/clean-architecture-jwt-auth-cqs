using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Users
{
    public record UserReadDto(Guid Id, 
        string? Email,
        string? FirstName,
        string? LastName ,
        string? Role,
        bool IsApproved);
    
}
