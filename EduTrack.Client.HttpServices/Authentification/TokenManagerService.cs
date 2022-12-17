using Blazored.LocalStorage;
using EduTrack.WebUI.Shared.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices.Authentification
{
    public class TokenManagerService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        private readonly string _tokenPath;
        private readonly string _refreshTokenPath;

        public TokenManagerService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            IConfiguration configuration)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;

            _tokenPath = configuration.GetSection("JwtSettings:StoragePath:Token").Value;
            _refreshTokenPath = configuration.GetSection("JwtSettings:StoragePath:RefreshToken").Value;
        }

        public async Task<string> GetTokenAsync()
        {
            string token = await _localStorage.GetItemAsync<string>(_tokenPath);
            return token;
        }

        public async Task SetTokenAsync(string token)
        {
            await _localStorage.SetItemAsync(_tokenPath, token);
        }

        private bool ValidateTokenExpiration(string token)
        {
            List<Claim> claims = JwtParser.ParseClaimsFromJwt(token).ToList();

            if (claims?.Count == 0)
            {
                return false;
            }
            string expirationSeconds = claims.Where(_ => _.Type.ToLower() == "exp").Select(_ => _.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(expirationSeconds))
            {
                return false;
            }

            var exprationDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(expirationSeconds));
            if (exprationDate < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        private async Task<string> RefreshTokenEndPoint(RefreshTokenDto refreshToken)
        {
            /*var response = await _httpClient.PostAsJsonAsync<TokenModel>("/account/activate-token-by-refreshtoken", tokenModel);
            if (!response.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            AuthResponse authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
            await _localStorageService.SetItemAsync<string>("token", authResponse.Token);
            await _localStorageService.SetItemAsync<string>("refreshToken", authResponse.RefreshToken);
            return authResponse.Token;*/
            return "";
        }
    }
}
