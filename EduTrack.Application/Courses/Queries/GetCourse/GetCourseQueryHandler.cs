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

namespace EduTrack.Application.Courses.Queries.GetCourses
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, ErrorOr<Course>>
    {
        private readonly ICourseRepository courseRepository;

        public GetCourseQueryHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<Course>> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.CourseId);

            if (course is null)
                return Errors.Course.NotFound;

            if(course.OwnerId != request.TeacherUserId)
                return Errors.Course.AccessDenied;

            return course;
        }
    }
}
