using EduTrack.Application.Courses.Queries.GetCourses;
using EduTrack.WebUI.Shared.Dtos.Courses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypesController : ApiController
    {
        public CourseTypesController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(Shared.ApiHelpers.ApiUrl.Courses.Types)]
        public async Task<IEnumerable<CourseTypeDto>> GetListAsync()
        {
            var result = await _mediator.Send(new GetCourseTypesQuery());
            return _mapper.Map<IEnumerable<CourseTypeDto>>(result);
        }
    }
}
