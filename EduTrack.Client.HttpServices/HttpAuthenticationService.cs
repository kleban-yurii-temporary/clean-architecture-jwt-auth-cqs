using EduTrack.Contracts.Authentication;
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

        public async Task<ProblemOr<AuthenticationResponseDto>> LoginAsync(UserLoginDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", request);
           
            return response.IsSuccessStatusCode
                ? new ProblemOr<AuthenticationResponseDto> { Value = await response.Content.ReadFromJsonAsync<AuthenticationResponseDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<AuthenticationResponseDto>>();
        }
    }
}