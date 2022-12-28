using EduTrack.Application.Authentication.Commands.Register;
using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain.AppErrors;

namespace EduTrack.Application.Users.Commands.ChangeRole
{
    public class UpdateRoleCommandHandler
        : IRequestHandler<UpdateRoleCommand, ErrorOr<bool>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private string[] allowedRoles = new[] { "student", "teacher" };

        public async Task<ErrorOr<bool>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserAsync(command.Id);

            if (user is null)
            {
                return Errors.User.NotFound;
            }

            if (allowedRoles.All(x => x != command.Role))
            {
                return Errors.User.RoleNotFound;
            }
            
            return await _userRepository.AddUserToRoleAsync(command.Id, command.Role); 
        }
    }
}
