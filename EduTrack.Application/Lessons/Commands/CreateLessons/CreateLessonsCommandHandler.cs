using EduTrack.Application.Common.Interfaces.Persistence;
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

namespace EduTrack.Application.Lessons.Commands.CreateLessons
{
    public class CreateLessonsCommandHandler : IRequestHandler<CreateLessonsCommand, ErrorOr<bool>>
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILessonsRepository lessonRepository;

        public CreateLessonsCommandHandler(
           ICourseRepository courseRepository,
           ILessonsRepository lessonRepository)
        {
            this.courseRepository = courseRepository;
            this.lessonRepository = lessonRepository;
        }

        public async Task<ErrorOr<bool>> Handle(CreateLessonsCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.CourseId);

            if (course.OwnerId != request.TeacherId) 
                return Errors.Course.AccessDenied;

            return await lessonRepository.CreateAsync(request.CourseId, request.Count, request.Type);
        }
    }
}
