using EduTrack.Application.Authentication.Common;
using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
         : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHashGenerator _passwordGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenService jwtTokenService,
            IPasswordHashGenerator passwordGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _passwordGenerator = passwordGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByEmailAsync(query.Email);

            if (user is null)
            {
                return Domain.Errors.Errors.User.NotFound;
            }

            if(!user.IsApproved)
            {
                return Domain.Errors.Errors.User.NotApproved;
            }

            if (!_passwordGenerator.VerifyPasswordHash(query.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Domain.Errors.Errors.Authentication.InvalidPassword;
            }

            var token = _jwtTokenService.GenerateToken(user);

            user.RefreshToken = _jwtTokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(_jwtTokenService.TokenExpiriesMinutes);

            await _userRepository.UpdateAsync(user);

            return new AuthenticationResult(token, user.RefreshToken);
        }
    }
}
