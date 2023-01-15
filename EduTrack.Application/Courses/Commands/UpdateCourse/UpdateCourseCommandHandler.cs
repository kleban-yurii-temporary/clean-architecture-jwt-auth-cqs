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

namespace EduTrack.Application.Courses.Commands.CreateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ErrorOr<bool>>
    {
        private readonly ICourseRepository courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.Course.Id);

            if (course.OwnerId != request.TeacherId)
                return Errors.Course.AccessDenied;

            return await courseRepository.UpdateAsync(request.Course);
        }
    }
}
