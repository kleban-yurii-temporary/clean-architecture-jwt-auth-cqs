using EduTrack.Domain.Entities;

namespace EduTrack.Application.Authentication.Common
{
    public record AuthenticationResult(        
        string? Token,
        string? RefreshToken);    
}