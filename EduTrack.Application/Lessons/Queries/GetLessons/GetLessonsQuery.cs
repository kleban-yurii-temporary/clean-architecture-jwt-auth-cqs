using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Lessons.Queries.GetLessons
{
    public record GetLessonsQuery(
        Guid CourseId,
        LessonType Type,
        Guid TeacherId): IRequest<IEnumerable<Lesson>>;
    
}
