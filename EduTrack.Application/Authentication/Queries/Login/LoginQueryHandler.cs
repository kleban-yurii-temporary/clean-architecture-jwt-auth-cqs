using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain.AppErrors;
using EduTrack.Helpers.Password;

namespace EduTrack.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
         : IRequestHandler<LoginQuery, ErrorOr<string>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenService jwtTokenService,
            IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<string>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByEmailAsync(query.Email);

            if (user is null)
            {
                return Errors.User.NotFound;
            }

            if(!user.IsApproved)
            {
                return Errors.User.NotApproved;
            }

            if (!PasswordService.VerifyPasswordHash(query.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Errors.Authentication.InvalidPassword;
            }

            return _jwtTokenService.GenerateToken(user);
        }
    }
}
