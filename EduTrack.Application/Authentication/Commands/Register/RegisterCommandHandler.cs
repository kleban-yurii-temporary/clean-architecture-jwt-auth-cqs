using EduTrack.Application.Authentication.Common;
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
using DomainErrors = EduTrack.Domain.Errors;

namespace EduTrack.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler 
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordGenerator _passwordGenerator;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordGenerator passwordGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordGenerator= passwordGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByEmailAsync(command.Email);

            if (user is not null)
            {
                return DomainErrors.Errors.Authentication.DuplicateEmail;
            }

            var (hash, salt) = _passwordGenerator.CreatePasswordHash(command.Password);

            user = new User
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PasswordHash = hash,
                PasswordSalt = salt
            };
                        
            await _userRepository.AddAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
