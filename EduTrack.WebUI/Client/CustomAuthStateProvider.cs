using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Http.Headers;
using EduTrack.WebUI.Client.HttpServices.Authentification;
using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Dtos.Authentication;
using System.Net.Http.Json;
using EduTrack.Helpers.Jwt;
using Syncfusion.Blazor.Diagrams;
using Newtonsoft.Json.Linq;
using System.Security.Principal;

namespace EduTrack.WebUI.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly TokenManagerService _tokenManager;
        private readonly HttpClient _httpClient;

        public CustomAuthStateProvider(
            HttpClient httpClient,
            TokenManagerService tokenManager)
        {
            _httpClient = httpClient;
            _tokenManager = tokenManager;
        }

        private async Task<string> RefreshTokenAsync(string token)
        {
            var response = await _httpClient.PostAsJsonAsync(
                WebUI.Shared.ApiHelpers.ApiUrl.Authentication.RefreshToken,
                new RefreshTokenRequest
                (
                    token, await _tokenManager.GetRefreshTokenAsync()
                ));

            if (response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadAsStringAsync();
                await _tokenManager.SetAccessTokenAsync(token);
            }
            else
            {
                token = null;
                _httpClient.DefaultRequestHeaders.Authorization = null;
                await _tokenManager.DropAccessTokenAsync();
                await _tokenManager.DropRefreshTokenAsync();
            }

            return token??string.Empty;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _tokenManager.GetAccessTokenAsync();
            var identity = new ClaimsIdentity();

            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                if(_tokenManager.IsTokenExpired(token))
                {
                    token = await RefreshTokenAsync(token);
                }

                var claims = JwtParser.ParseClaimsFromJwt(token);
                identity = new ClaimsIdentity(claims, "jwt");

                _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
