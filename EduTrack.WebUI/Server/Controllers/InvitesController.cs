using EduTrack.Application.Invites.Commands.GetInvites;
using EduTrack.Application.Invites.Queries.GetInvites;
using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Dtos.Invites;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ApiController
    {
        public InvitesController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(ApiUrl.Invites.All)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> GetListAsync(Guid courseId)
        {
            var result = await _mediator.Send(new GetInvitesQuery(courseId, (Guid)CurrentUserId));

            return result.Match(
               result => Ok(_mapper.Map<IEnumerable<InviteDto>>(result)),
               errors => Problem(errors));
        }

        [HttpPost(ApiUrl.Invites.Create)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> CreateAsync(Guid courseId)
        {
            var result = await _mediator.Send(new CreateInviteCommand(courseId, (Guid)CurrentUserId));

            return result.Match(
               result => Ok(_mapper.Map<InviteDto>(result)),
               errors => Problem(errors));
        }

        [AllowAnonymous]
        [HttpGet(ApiUrl.Invites.PublicDetails)]
        public async Task<IActionResult> GetInviteDetailsAsync(Guid id)
        {
            var result = await _mediator.Send(new GetDetailedInviteQuery(id));

            return result.Match(
               result => Ok(_mapper.Map<DetailedInviteDto>(result)),
               errors => Problem(errors));
        } 
    }
}
