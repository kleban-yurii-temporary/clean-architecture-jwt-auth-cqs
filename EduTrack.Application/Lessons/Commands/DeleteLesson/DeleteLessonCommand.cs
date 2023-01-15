using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Lessons.Commands.DeleteLesson
{
    public record DeleteLessonCommand(Guid Id, bool IsGroup, Guid TeacherId): IRequest<ErrorOr<bool>>;
    
}
