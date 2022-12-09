using EduTrack.Application.Authentication.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Users.Commands.ChangeRole
{
    public record UpdateRoleCommand(
        Guid Id,
        string Role) : IRequest<ErrorOr<bool>>;
}
