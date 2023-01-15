using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Invites.Queries.GetInvites
{
    public record GetDetailedInviteQuery(Guid Id) : IRequest<ErrorOr<CourseInvite>>;
}
