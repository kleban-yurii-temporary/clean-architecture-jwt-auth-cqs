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

namespace EduTrack.Application.Invites.Commands.GetInvites
{
    public class CreateInviteCommandHandler : IRequestHandler<CreateInviteCommand, ErrorOr<CourseInvite>>
    {
        private readonly IInviteRepository inviteRepository;
        private readonly ICourseRepository courseRepository;

        public CreateInviteCommandHandler(IInviteRepository inviteRepository, ICourseRepository courseRepository)
        {
            this.inviteRepository = inviteRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<CourseInvite>> Handle(CreateInviteCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.CourseId);

            if(course.OwnerId != request.TeacherId)
            {
                return Errors.Course.AccessDenied;
            }

            var invite = await inviteRepository.Create(request.CourseId);

            return invite;
        }
    }
}
