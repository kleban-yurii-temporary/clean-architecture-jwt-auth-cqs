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
    public class GetStudentsAndGroupsQueryHandler : IRequestHandler<GetStudentsAndGroupsQuery, ErrorOr<Course>>
    {
        private readonly ICourseRepository courseRepository;

        public GetStudentsAndGroupsQueryHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<Course>> Handle(GetStudentsAndGroupsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetWithStudentsAndGroupsDetailsAsync(request.CourseId);

            if (course is null)
                return Errors.Course.NotFound;

            if(course.OwnerId != request.TeacherUserId)
                return Errors.Course.AccessDenied;

            return course;
        }
    }

}
