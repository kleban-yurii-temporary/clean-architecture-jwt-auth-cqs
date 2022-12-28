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
using EduTrack.Helpers.Crypto;

namespace EduTrack.Application.Authentication.Commands.Register
{
    public class CreateRefreshTokenCommandHandler 
        : IRequestHandler<CreateRefreshTokenCommand, ErrorOr<RefreshTokenResult>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;

        public CreateRefreshTokenCommandHandler(
            IJwtTokenService jwtTokenService,
            IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<RefreshTokenResult>> Handle(CreateRefreshTokenCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByEmailAsync(command.Email);

            if (user is null)            
                return Errors.User.NotFound;                       

            var tokenPlain = _jwtTokenService.GenerateRefreshToken();

            user.RefreshToken = tokenPlain;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_jwtTokenService.RefreshTokenExpiriesMinutes);

            await _userRepository.UpdateAsync(user);

            return new RefreshTokenResult(CryptoService.Encrypt(tokenPlain, user.Id.ToString()), user.RefreshTokenExpiryTime);            
        }
    }
}
