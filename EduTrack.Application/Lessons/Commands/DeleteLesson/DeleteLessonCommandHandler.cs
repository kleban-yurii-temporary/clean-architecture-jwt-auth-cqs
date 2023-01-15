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

namespace EduTrack.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, ErrorOr<bool>>
    {
        private readonly ILessonsRepository lessonRepository;

        public DeleteLessonCommandHandler(
           ILessonsRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

             if (request.TeacherId != lessonRepository.GetOwnerId(request.Id)) 
                return Errors.Course.AccessDenied;

            return await lessonRepository.DeleteAsync(request.Id, request.IsGroup);
        }
    }
}
