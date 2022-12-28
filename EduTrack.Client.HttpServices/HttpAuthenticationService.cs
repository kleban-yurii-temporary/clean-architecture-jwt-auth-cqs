using EduTrack.Contracts.Authentication;
using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Dtos.Authentication;
using System.Net.Http.Json;
using System.Text.Json;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpAuthenticationService : HttpBaseService
    {
        public HttpAuthenticationService(HttpClient httpClient) : base(httpClient) { }

        public async Task<ProblemOr<AuthenticationResponse>> LoginAsync(UserLoginDto request)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl.Authentication.Login, request);
           
            return response.IsSuccessStatusCode
                ? new ProblemOr<AuthenticationResponse> { Value = await response.Content.ReadFromJsonAsync<AuthenticationResponse>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<AuthenticationResponse>>();
        }

    }
}