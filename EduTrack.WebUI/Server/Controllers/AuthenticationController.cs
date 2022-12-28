using EduTrack.Application.Authentication.Commands.RefreshToken;
using EduTrack.Application.Authentication.Commands.Register;
using EduTrack.Application.Authentication.Queries.Login;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Contracts.Authentication;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Dtos.Authentication;
using EduTrack.WebUI.Shared.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduTrack.WebUI.Shared.ApiHelpers;
using Microsoft.AspNetCore.Authorization;

namespace EduTrack.WebUI.Server.Controllers
{
    /// <summary>
    /// Auth
    /// </summary>
    [Route("api/auth")]
    public class AuthenticationController : ApiController
    {
        public AuthenticationController(
            IMediator mediator,
            IMapper mapper) : base(mediator, mapper) {}

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAuthDataAsync()
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

        /// <summary>
        /// Register API
        /// </summary>
        /// <param name="request"></param>
        /// <returns>request</returns>
        [HttpPost(ApiUrl.Authentication.Register)]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var authResult = await _mediator.Send(command);


            return authResult.Match(
                authResult => Ok(authResult),
                errors => Problem(errors));
        }

        [HttpPost(ApiUrl.Authentication.Login)]
        public async Task<IActionResult> LoginAsync(UserLoginDto request)
        {
            var loginQuery = _mapper.Map<LoginQuery>(request);
            var jwt = await _mediator.Send(loginQuery);
           
            if (jwt.IsError && jwt.FirstError == EduTrack.Domain.AppErrors.Errors.Authentication.InvalidPassword)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: jwt.FirstError.Description);
            }

            var refreshToken = await _mediator.Send(new CreateRefreshTokenCommand(request.Email));

            return jwt.Match(
                authResult => Ok(new AuthenticationResponse(
                    jwt.Value,
                    refreshToken.Value.Token)),
                errors => Problem(errors));
        }

        [HttpPost(ApiUrl.Authentication.RefreshToken)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)          
        {
            var command = _mapper.Map<RefreshTokenCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
