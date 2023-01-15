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
    public class GetCourseTypesQueryHandler : IRequestHandler<GetCourseTypesQuery, IEnumerable<CourseType>>
    {
        private readonly ICourseTypeRepository typeRepository;

        public GetCourseTypesQueryHandler(ICourseTypeRepository courseTypeRepository)
        {
            this.typeRepository = courseTypeRepository;
        }

        public async Task<IEnumerable<CourseType>> Handle(GetCourseTypesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return await typeRepository.GetListAsync();
        }
    }
}
