using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Commands;
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

namespace EduTrack.Application.StudentRecords.Commands.CreateStudentRecord
{
    public class CreateSubGroupCommandHandler : IRequestHandler<CreateSubGroupCommand, ErrorOr<SubGroup>>
    {
        private readonly ISubGroupsRepository subGroupsRepository;
        private readonly ICourseRepository courseRepository;

        public CreateSubGroupCommandHandler(
            ISubGroupsRepository subGroupsRepository,
            ICourseRepository courseRepository)
        {
            this.subGroupsRepository = subGroupsRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<SubGroup>> Handle(CreateSubGroupCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.CourseId);

            if (course.OwnerId != request.TeacherId) 
                return Errors.Course.AccessDenied;

            return await subGroupsRepository.CreateAsync(request.CourseId);
        }
    }
}
