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
using EduTrack.Application.OtherCourses.Queries.GeTeachertOtherCourses;

namespace EduTrack.Application.Courses.Queries.GetCourses
{
    public class GetTeacherOtherCoursesQueryHandler : IRequestHandler<GetTeacherOtherCoursesQuery, ErrorOr<IEnumerable<OtherCourse>>>
    {
        private readonly IOtherCourseRepository otherCourseRepository;

        public GetTeacherOtherCoursesQueryHandler(IOtherCourseRepository otherCourseRepository)
        {
            this.otherCourseRepository = otherCourseRepository;
        }

        public async Task<ErrorOr<IEnumerable<OtherCourse>>> Handle(GetTeacherOtherCoursesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var courses = await otherCourseRepository.GetListAsync();
            courses = courses.Where(x => x.OwnerId == request.TeacherUserId);

            return courses.ToList();
        }
    }
}
