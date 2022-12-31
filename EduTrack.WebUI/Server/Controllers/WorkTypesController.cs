using EduTrack.Application.WorkTypes.Queries;
using EduTrack.WebUI.Shared.Dtos.WorkTypes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class WorkTypesController : ApiController
    {
        public WorkTypesController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }


        [HttpGet(Shared.ApiHelpers.ApiUrl.WorkTypes.All)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetWorkTypesQuery());

            return Ok(_mapper.Map<IEnumerable<WorkTypeDto>>(result));
        }
    }
}
