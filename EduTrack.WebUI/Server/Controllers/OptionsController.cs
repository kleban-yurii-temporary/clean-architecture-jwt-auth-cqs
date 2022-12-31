using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.WebUI.Shared.Dtos.Options;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ApiController
    {
        public OptionsController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(Shared.ApiHelpers.ApiUrl.Options.All)]
        [Authorize]
        public async Task<IActionResult> GetAllAsync(bool ownOnly = true)
        {            
            var result = await _mediator.Send(new GetOptionsQuery(CurrentUserId, ownOnly));
            return Ok(_mapper.Map<IEnumerable<OptionDto>>(result));
        }
    }
}
