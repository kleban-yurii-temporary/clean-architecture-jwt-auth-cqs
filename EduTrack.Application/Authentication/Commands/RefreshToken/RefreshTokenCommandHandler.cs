using EduTrack.Application.Authentication.Commands.RefreshToken;
using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain.AppErrors;
using EduTrack.Helpers.Jwt;
using EduTrack.Helpers.Crypto;
using IdentityModel;

namespace EduTrack.Application.Authentication.Commands.Register
{
    public class RefreshTokenCommandHandler 
        : IRequestHandler<RefreshTokenCommand, ErrorOr<string>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;

        public RefreshTokenCommandHandler(
            IJwtTokenService jwtTokenService,
            IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<string>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var claims = JwtParser.ParseClaimsFromJwt(command.AccessToken);

            if (!claims.Any(x=> x.Type == JwtClaimTypes.Id))            
                return Errors.Authentication.InvalidToken;
            
            var userId = Guid.Parse(claims.First(x => x.Type == JwtClaimTypes.Id).Value);
            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)            
                return Errors.User.NotFound;

            var tokenPlain = CryptoService.Decrypt(command.RefreshToken, userId.ToString());

            if (user.RefreshTokenExpiryTime > DateTime.UtcNow || user.RefreshToken == tokenPlain)
                return Errors.Authentication.RefreshTokenExpired;

            return _jwtTokenService.GenerateToken(user);
        }
    }
}
