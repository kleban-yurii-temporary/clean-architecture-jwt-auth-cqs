using EduTrack.Application.Specialities.Queries.GetSpecialities;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Dtos.Specialities;
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
    public class SpecController : ApiController
    {
        public SpecController(IMediator mediator, IMapper mapper) 
            : base(mediator, mapper) { }

        [HttpGet(Shared.ApiHelpers.ApiUrl.Specialities.All)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetSpecialitiesQuery());

            return Ok(_mapper.Map<IEnumerable<SpecialityDto>>(result));
        }
    }
}
