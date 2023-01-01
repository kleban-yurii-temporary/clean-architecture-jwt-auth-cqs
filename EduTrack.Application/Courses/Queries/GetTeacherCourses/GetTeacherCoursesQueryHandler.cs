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
    public class GetTeacherCoursesQueryHandler : IRequestHandler<GetTeacherCoursesQuery, ErrorOr<List<Course>>>
    {
        private readonly ICourseRepository courseRepository;

        public GetTeacherCoursesQueryHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<List<Course>>> Handle(GetTeacherCoursesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var courses = await courseRepository.GetListAsync();
            courses = courses.Where(x => x.OwnerId == request.TeacherUserId);

            return courses.ToList();
        }
    }
}
