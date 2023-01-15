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
    public class GetDetailedInviteQueryHandler : IRequestHandler<GetDetailedInviteQuery, ErrorOr<CourseInvite>>
    {
        private readonly IInviteRepository inviteRepository;
        private readonly ICourseRepository courseRepository;

        public GetDetailedInviteQueryHandler(
            IInviteRepository inviteRepository, 
            ICourseRepository courseRepository)
        {
            this.inviteRepository = inviteRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<CourseInvite>> Handle(GetDetailedInviteQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var invite = await inviteRepository.GetAsync(request.Id);

            if (invite == null) return Errors.Invite.NotFound;                       

            if (invite.ExpiryOn < DateTime.UtcNow) return Errors.Invite.Expired;

            if (invite.IsDeactivated) return Errors.Invite.Deactivated;

            var course = await courseRepository.GetAsync(invite.Course.Id);

            if (course is null) return Errors.Course.NotFound;

            if (!course.IsActive) return Errors.Course.Inactive;

            return invite;
        }
    }
}
