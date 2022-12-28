using EduTrack.Domain.Entities;

namespace EduTrack.Application.Authentication.Commands.RefreshToken
{
    public record RefreshTokenResult(
        string Token,
        DateTime ExpiryDate);
}