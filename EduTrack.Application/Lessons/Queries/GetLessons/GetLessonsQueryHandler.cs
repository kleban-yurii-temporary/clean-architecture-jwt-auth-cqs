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

namespace EduTrack.Application.Lessons.Queries.GetLessons
{
    public class GetLessonsQueryHandler : IRequestHandler<GetLessonsQuery, IEnumerable<Lesson>>
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILessonsRepository lessonRepository;

        public GetLessonsQueryHandler(
           ICourseRepository courseRepository,
           ILessonsRepository lessonRepository)
        {
            this.courseRepository = courseRepository;
            this.lessonRepository = lessonRepository;
        }

        public async Task<IEnumerable<Lesson>> Handle(GetLessonsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var list = await lessonRepository.GetAsync(request.CourseId, request.Type);
            return list;
        }
    }
}
