using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Lessons.Commands.CreateLessons
{
    public record CreateLessonsCommand(
        Guid CourseId,
        int Count,
        LessonType Type,
        Guid TeacherId): IRequest<ErrorOr<bool>>;
    
}
