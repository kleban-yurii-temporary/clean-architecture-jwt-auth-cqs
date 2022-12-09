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
         : IRequestHandler<UserQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordGenerator passwordGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordGenerator = passwordGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(UserQuery query, CancellationToken cancellationToken)
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

            var token = _jwtTokenGenerator.GenerateToken(user); 
            
           _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
