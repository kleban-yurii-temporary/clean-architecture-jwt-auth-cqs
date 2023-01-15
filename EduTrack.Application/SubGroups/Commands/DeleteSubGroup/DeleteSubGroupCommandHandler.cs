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
    public class DeleteSubGroupCommandHandler : IRequestHandler<DeleteSubGroupCommand, ErrorOr<bool>>
    {
        private readonly ISubGroupsRepository subGroupsRepository;
        private readonly ICourseRepository courseRepository;

        public DeleteSubGroupCommandHandler(
            ISubGroupsRepository subGroupsRepository,
            ICourseRepository courseRepository)
        {
            this.subGroupsRepository = subGroupsRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteSubGroupCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var subGroup = await subGroupsRepository.GetAsync(request.Id);

            var course = await courseRepository.GetAsync(subGroup.Course.Id);

            if (course.OwnerId != request.TeacherId) 
                return Errors.Course.AccessDenied;

            if (subGroup.Students.Any())
                return Errors.Course.SubGroupHasStudents;

            return await subGroupsRepository.DeleteAsync(request.Id);
        }
    }
}
