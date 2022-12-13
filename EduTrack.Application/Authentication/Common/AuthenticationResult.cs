using EduTrack.Domain.Entities;

namespace EduTrack.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string? Token
       );    
}