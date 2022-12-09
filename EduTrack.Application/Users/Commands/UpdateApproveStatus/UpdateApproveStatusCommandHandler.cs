using EduTrack.Application.Authentication.Commands.Register;
using EduTrack.Application.Authentication.Common;
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
using DomainErrors = EduTrack.Domain.Errors;

namespace EduTrack.Application.Users.Commands.ChangeRole
{
    public class UpdateApproveStatusCommandHandler
        : IRequestHandler<UpdateApproveStatusCommand, ErrorOr<bool>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateApproveStatusCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateApproveStatusCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userRepository.GetUserAsync(command.Id);

            if (user is null)
            {
                return Domain.Errors.Errors.User.NotFound;
            }
            
            return await _userRepository.UpdateUserApproveStatusAsync(command.Id, command.IsApproved); 
        }
    }
}
