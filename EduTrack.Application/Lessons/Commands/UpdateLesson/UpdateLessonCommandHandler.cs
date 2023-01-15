using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Lessons.Commands.CreateLessons;
using EduTrack.Application.Options.Commands;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.AppErrors;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, ErrorOr<bool>>
    {
        private readonly ILessonsRepository lessonRepository;

        public UpdateLessonCommandHandler(
           ILessonsRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

             if (request.TeacherId != lessonRepository.GetOwnerId(request.Lesson.Id)) 
                return Errors.Course.AccessDenied;

            return await lessonRepository.UpdateAsync(request.Lesson, request.IsGroup);
        }
    }
}
