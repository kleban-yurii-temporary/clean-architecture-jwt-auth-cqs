using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.AppErrors;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EduTrack.Domain.AppErrors.Errors;

namespace EduTrack.Application.Invites.Queries.GetInvites
{
    public class GetInvitesQueryHandler : IRequestHandler<GetInvitesQuery, ErrorOr<IEnumerable<CourseInvite>>>
    {
        private readonly IInviteRepository inviteRepository;
        private readonly ICourseRepository courseRepository;

        public GetInvitesQueryHandler(
            IInviteRepository inviteRepository, 
            ICourseRepository courseRepository)
        {
            this.inviteRepository = inviteRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<IEnumerable<CourseInvite>>> Handle(GetInvitesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.CourseId);

            if (course.OwnerId != request.TeacherId) return Errors.Course.AccessDenied;            

            var invites = await inviteRepository.ListAsync(request.CourseId);

            return invites.ToList();
        }
    }
}
