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

namespace EduTrack.Application.Courses.Queries.GetCourses
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ErrorOr<Guid>>
    {
        private readonly ICourseRepository courseRepository;
        private readonly ICourseTypeRepository courseTypeRepository;
        public CreateCourseCommandHandler(ICourseRepository courseRepository, ICourseTypeRepository courseTypeRepository)
        {
            this.courseRepository = courseRepository;
            this.courseTypeRepository = courseTypeRepository;
        }

        public async Task<ErrorOr<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var id = await courseRepository.AddAsync(new Course
            {
                OwnerId = request.TeacherUserId,
                EduYear = "-",
                GroupCode = "-",
                Semestr = 1,
                Type = (await courseTypeRepository.GetListAsync()).First(),
                Title = "Новий курс"
            });            

            return id;
        }
    }
}
