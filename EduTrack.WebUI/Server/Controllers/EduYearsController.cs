using EduTrack.Application.EduYears.Queries;
using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Dtos.Courses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EduYearsController : ApiController
    {
        public EduYearsController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(ApiUrl.Courses.EduYears)]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediator.Send(new GetEduYearsQuery());
            return Ok(_mapper.Map<IEnumerable<EduYearDto>>(result));
        }
    }
}
