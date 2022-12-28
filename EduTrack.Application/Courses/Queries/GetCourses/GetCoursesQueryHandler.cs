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
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, ErrorOr<List<Course>>>
    {
        private readonly ICourseRepository courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<List<Course>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var courses = await courseRepository.GetListAsync();

            return courses.ToList();
        }
    }
}
