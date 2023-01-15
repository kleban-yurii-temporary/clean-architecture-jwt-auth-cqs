using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Invites.Commands.GetInvites
{
    public record CreateInviteCommand(Guid CourseId, Guid TeacherId)
        : IRequest<ErrorOr<CourseInvite>>;
}
