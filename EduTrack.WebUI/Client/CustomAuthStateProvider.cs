using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Http.Headers;
using EduTrack.WebUI.Client.HttpServices.Authentification;

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
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _tokenManager.GetTokenAsync();

            var identity = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            Console.WriteLine($"state: {state.User.Identity.IsAuthenticated}");

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
            
    }
}
