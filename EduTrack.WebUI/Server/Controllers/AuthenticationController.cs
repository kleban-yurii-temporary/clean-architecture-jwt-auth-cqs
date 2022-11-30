using EduTrack.Application.Authentication.Commands.Register;
using EduTrack.Application.Authentication.Common;
using EduTrack.Application.Authentication.Queries.Login;
using EduTrack.Contracts.Authentication;
using EduTrack.WebUI.Shared.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DomainErrors = EduTrack.Domain.Errors;

namespace EduTrack.WebUI.Server.Controllers
{
    /// <summary>
    /// Auth
    /// </summary>
    [Route("api/auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Register API
        /// </summary>
        /// <param name="request"></param>
        /// <returns>request</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponseDto>(authResult)),
                errors => Problem(errors));
        }

        /// <summary>
        /// Login API mathod
        /// </summary>
        /// <param name="request"></param>
        /// <returns>AuthenticationResponse Object</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == DomainErrors.Errors.Authentication.InvalidPassword)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponseDto>(authResult)),
                errors => Problem(errors));
        }
    }
}
