using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.OtherCourses.Queries.GeTeachertOtherCourses
{
    public record GetTeacherOtherCoursesQuery(Guid TeacherUserId) : IRequest<ErrorOr<IEnumerable<OtherCourse>>> { }
}
