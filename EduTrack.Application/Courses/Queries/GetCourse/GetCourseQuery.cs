using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Courses.Queries.GetCourses
{
    public record GetCourseQuery(Guid CourseId, Guid TeacherUserId) : IRequest<ErrorOr<Course>> { }

}
