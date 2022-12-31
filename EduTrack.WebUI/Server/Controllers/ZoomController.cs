using EduTrack.Application.Options.Commands;
using EduTrack.Application.Options.Keys.Zoom;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Zoom.Queries.GetAuthUrl;
using ErrorOr;
using IdentityModel.Client;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Zoom.Meeting.WebApi.Tmp;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZoomController : ApiController
    {
        public ZoomController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet("/api/zoom/auth_url")]
        public async Task<IActionResult> GetAuthUrlAsync(string client_url)
        {
            await _mediator.Send(new OptionNewOrUpdateCommand(OptionKeys.Client.Url, client_url, OptionKeys.ClientGroup));

            var result = await _mediator.Send(new GetZoomAuthUrlQuery((Guid)CurrentUserId));

            return result.Match(
               result => Ok(result),
               errors => Problem(errors));
        }

        [HttpGet("/api/zoom/oauthredirect")]
        public async Task<IActionResult> GetAuthCode(string code)
        {
            var saveCodeResult = await _mediator.Send(new OptionNewOrUpdateCommand(ZoomApiKeys.Authorize.AuthorizationCode, code, ZoomApiKeys.Group, (Guid)CurrentUserId));

            if (saveCodeResult.IsError)
            {
                return saveCodeResult.Match(
                  result => Ok(result),
                  errors => Problem(errors));
            }
            var tokenUrlResult = await _mediator.Send(new GetZoomTokenUrlQuery((Guid)CurrentUserId));

            if (tokenUrlResult.IsError)
            {
                return tokenUrlResult.Match(
               result => Ok(result),
               errors => Problem(errors));
            }

            var authHeaderTokenResult = await _mediator.Send(new GetZoomAuthBasicHeaderQuery((Guid)CurrentUserId));

            if (authHeaderTokenResult.IsError)
            {
                return authHeaderTokenResult.Match(
               result => Ok(result),
               errors => Problem(errors));
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeaderTokenResult.Value);

            var response = await client.PostAsync(tokenUrlResult.Value, null);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();

                await _mediator.Send(new OptionNewOrUpdateCommand(
                    tokenResponse.AccessToken,
                    ZoomApiKeys.Token.AccessToken,
                    ZoomApiKeys.Group,
                    CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   tokenResponse.RefreshToken,
                   ZoomApiKeys.Token.RefreshToken,
                   ZoomApiKeys.Group,
                   CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   tokenResponse.ExpiresIn.ToString(),
                   ZoomApiKeys.Token.TokenExpiresIn,
                   ZoomApiKeys.Group,
                   CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   tokenResponse.TokenType,
                   ZoomApiKeys.Token.AccessTokenType,
                   ZoomApiKeys.Group,
                   CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   tokenResponse.Scope,
                   ZoomApiKeys.Token.Scope,
                   ZoomApiKeys.Group,
                   CurrentUserId));

                return Ok(tokenResponse);
            }

            return Ok("ouuuuu");
        }

        [HttpGet("/api/zoom/me")]
        public async Task<IActionResult> Me()
        {
            var token = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Token.AccessToken, CurrentUserId));
            var url = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Users.Me, CurrentUserId));

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value.Value);

            var response = await client.GetAsync(url.Value.Value);

            return Ok(response.Content);

        }
    }

}
