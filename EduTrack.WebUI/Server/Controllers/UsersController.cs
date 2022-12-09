using EduTrack.Application.Authentication.Commands.Register;
using EduTrack.Application.Users.Commands.ChangeRole;
using EduTrack.Application.Users.Queries;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Contracts.Authentication;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _mediator.Send(new GetUsersQuery());

            return result.Match(
                authResult => Ok(result),
                errors => Problem(errors));
        }*/

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Problem(
                  statusCode: StatusCodes.Status401Unauthorized,
                  title: "Користувач не авторизований");
            }

            var result = await _mediator.Send(new GetUserByIdQuery(Guid.Parse(User.Claims.First().Value)));

            return result.Match(
                result => Ok(_mapper.Map<UserReadDto>(result)),
                errors => Problem(errors));
        }

        [HttpPut("role")]
        public async Task<IActionResult> UpdateRoleAsync(UpdateUserRoleDto userRoleDto)
        {
            var command = _mapper.Map<UpdateRoleCommand>(userRoleDto);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateApproveStatusAsync(UpdateUserStatusDto userStatusDto)
        {
            var command = _mapper.Map<UpdateApproveStatusCommand>(userStatusDto);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }       
    }
}
