using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain.AppErrors;

namespace EduTrack.Application.CheckRoleAccesss.Queries.IsEditAccessAllowed
{
    public class IsEditAccessAllowedQueryHandler : IRequestHandler<IsEditAccessAllowedQuery, ErrorOr<bool>>
    {
        private readonly ICourseRepository courseRepository;
        private readonly ISubGroupsRepository subGroupsRepository;
        private readonly IStudentRecordsRepository studentsRepository;
        private readonly IInviteRepository inviteRepository;
        private readonly ILessonsRepository lessonRepository;

        public IsEditAccessAllowedQueryHandler(
            ICourseRepository courseRepository,
            ILessonsRepository lessonRepository,
            ISubGroupsRepository subGroupsRepository,
             IStudentRecordsRepository studentsRepository,
             IInviteRepository inviteRepository)
        {
            this.courseRepository = courseRepository;
            this.lessonRepository = lessonRepository;
            this.subGroupsRepository = subGroupsRepository;
            this.studentsRepository = studentsRepository;
            this.inviteRepository = inviteRepository;
        }

        public async Task<ErrorOr<bool>> Handle(IsEditAccessAllowedQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (request.accessType == Common.EditAccessObjectType.Course && courseRepository.GetOwnerId(request.Id) == request.UserId
                || request.accessType == Common.EditAccessObjectType.SubGroup && subGroupsRepository.GetOwnerId(request.Id) == request.UserId
                || request.accessType == Common.EditAccessObjectType.Lesson && lessonRepository.GetOwnerId(request.Id) == request.UserId
                || request.accessType == Common.EditAccessObjectType.SudentRecord && studentsRepository.GetOwnerId(request.Id) == request.UserId
                || request.accessType == Common.EditAccessObjectType.Invite && inviteRepository.GetOwnerId(request.Id) == request.UserId)

                return Errors.Course.AccessDenied;

            return true;
        }
    }
}
