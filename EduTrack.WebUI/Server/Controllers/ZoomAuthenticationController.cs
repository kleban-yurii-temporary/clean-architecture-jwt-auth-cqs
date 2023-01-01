using EduTrack.Application.Options.Commands;
using EduTrack.Application.Options.Keys.Zoom;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Zoom.Queries.GetAuthUrl;
using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Dtos.Zoom;
using ErrorOr;
using IdentityModel.Client;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZoomAuthenticationController : ApiController
    {
        public ZoomAuthenticationController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }


        [HttpGet(ApiUrl.Zoom.OAuth.AuthorizeUrl)]
        public async Task<IActionResult> GetAuthUrlAsync(string redirect_url)
        {
            await _mediator.Send(new OptionNewOrUpdateCommand(ZoomApiKeys.Authorize.RedirectUrl, redirect_url, ZoomApiKeys.Group));

            var result = await _mediator.Send(new GetZoomAuthUrlQuery((Guid)CurrentUserId));

            return result.Match(
               result => Ok(result),
               errors => Problem(errors));
        }

        [HttpGet(ApiUrl.Zoom.OAuth.Redirect)]
        public async Task<IActionResult> OAuthRedirectAsync(string code)
        {
            var tokenUrlResult = await _mediator.Send(new GetZoomTokenUrlQuery((Guid)CurrentUserId, code));

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

            var request = new HttpRequestMessage(HttpMethod.Post, tokenUrlResult.Value);

            request.Content = new StringContent("",
                                      Encoding.UTF8,
                                      "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeaderTokenResult.Value);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<ZoomAccessTokenObjectDto>();

                await _mediator.Send(new OptionNewOrUpdateCommand(
                     ZoomApiKeys.Token.AccessToken,
                    tokenResponse.AccessToken,                   
                    ZoomApiKeys.Group,
                    CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   ZoomApiKeys.Token.RefreshToken,
                   tokenResponse.RefreshToken,                
                   ZoomApiKeys.Group,
                   CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   ZoomApiKeys.Token.TokenExpiresIn,
                   tokenResponse.ExpiresIn.ToString(),                
                   ZoomApiKeys.Group,
                   CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                   ZoomApiKeys.Token.AccessTokenType,
                   tokenResponse.TokenType,                
                   ZoomApiKeys.Group,
                   CurrentUserId));

                await _mediator.Send(new OptionNewOrUpdateCommand(
                     ZoomApiKeys.Token.Scope,
                   tokenResponse.Scope,                  
                   ZoomApiKeys.Group,
                   CurrentUserId));

                return Ok(tokenResponse);
            }             

            return Ok(response.Content.ToString());
        }

        [HttpGet(ApiUrl.Zoom.Users.Me)]
        public async Task<IActionResult> Me()
        {
            var token = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Token.AccessToken, CurrentUserId));
            var url = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Users.Me));

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value.Value);

            var response = await client.GetAsync(url.Value.Value);

            return Ok(response.Content.ReadAsStringAsync());

        }

        [HttpGet(ApiUrl.Zoom.Meetings.All)]
        public async Task<IActionResult> Meeetings()
        {
            var token = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Token.AccessToken, CurrentUserId));
            var url = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Users.Meetings));

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value.Value);

            var response = await client.GetAsync(url.Value.Value);

            return Ok(response.Content.ReadAsStringAsync());
        }

        [HttpGet(ApiUrl.Zoom.Webinars.All)]
        public async Task<IActionResult> Webinars()
        {
            var token = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Token.AccessToken, CurrentUserId));
            var url = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Users.Webinars));

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value.Value);

            var response = await client.GetAsync(url.Value.Value);

            return Ok(response.Content.ReadAsStringAsync());
        }

        [HttpGet(ApiUrl.Zoom.Recordings.All)]
        public async Task<IActionResult> Recordings()
        {
            var token = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Token.AccessToken, CurrentUserId));
            var url = await _mediator.Send(new GetOptionQuery(ZoomApiKeys.Users.Recordings));

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value.Value);

            var response = await client.GetAsync(url.Value.Value);

            return Ok(response.Content.ReadAsStringAsync());
        }
    }

}
