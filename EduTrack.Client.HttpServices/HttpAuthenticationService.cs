using EduTrack.Contracts.Authentication;
using EduTrack.WebUI.Shared.Authentication;
using ErrorOr;
using System.Net.Http.Json;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpAuthenticationService : HttpBaseService
    {
        public HttpAuthenticationService(HttpClient httpClient) : base(httpClient) { }

        public async Task<ErrorOr<AuthenticationResponseDto>> LoginAsync(UserLoginDto request)
        {
            var response = await _httpClient.PostAsJsonAsync<UserLoginDto>("/api/auth/login", request);
            return await response.Content.ReadFromJsonAsync<ErrorOr<AuthenticationResponseDto>>();           
        }

    }
}