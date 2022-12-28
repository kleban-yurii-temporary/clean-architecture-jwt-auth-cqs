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
using EduTrack.Helpers.Password;

namespace EduTrack.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler 
        : IRequestHandler<RegisterCommand, ErrorOr<Guid>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenService jwtTokenService,
            IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Guid>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserByEmailAsync(command.Email);

            if (user is not null)
            {
                return Errors.Authentication.DuplicateEmail;
            }

            var (hash, salt) = PasswordService.CreatePasswordHash(command.Password);

            user = new User
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PasswordHash = hash,
                PasswordSalt = salt
            };
                        
            var userId = await _userRepository.AddAsync(user);           

            return userId;
        }
    }
}
