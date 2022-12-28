using Blazored.LocalStorage;
using EduTrack.Helpers.Jwt;
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

        private readonly string _accessTokenPath;
        private readonly string _refreshTokenPath;

        public TokenManagerService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            IConfiguration configuration)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;

            _accessTokenPath = configuration.GetSection("JwtSettings:StoragePath:AccessToken").Value;
            _refreshTokenPath = configuration.GetSection("JwtSettings:StoragePath:RefreshToken").Value;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(_accessTokenPath);
        }

        public async Task SetAccessTokenAsync(string accessToken)
        {
            await _localStorage.SetItemAsync(_accessTokenPath, accessToken);
        }

        public async Task DropAccessTokenAsync()
        {
            await _localStorage.RemoveItemAsync(_accessTokenPath);
        }

        public async Task<string> GetRefreshTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(_refreshTokenPath);
        }

        public async Task SetRefreshTokenAsync(string refreshToken)
        {
            await _localStorage.SetItemAsync(_refreshTokenPath, refreshToken);
        }

        public bool IsTokenExpired(string token)
        {
            List<Claim> claims = JwtParser.ParseClaimsFromJwt(token).ToList();

            if (claims?.Count == 0)  return true;
            
            string expirationSeconds = claims.Where(_ => _.Type.ToLower() == "exp").Select(_ => _.Value).FirstOrDefault();
            
            if (string.IsNullOrEmpty(expirationSeconds)) return true;
            
            var exprationDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(expirationSeconds));

            Console.WriteLine($"Current Date&Time: {DateTime.UtcNow}");
            Console.WriteLine($"Access Token Expiration Date&Time: {exprationDate} / {exprationDate < DateTime.UtcNow}");

            return (exprationDate < DateTime.UtcNow);
        }

        public async Task DropRefreshTokenAsync()
        {
            await _localStorage.RemoveItemAsync(_refreshTokenPath);
        }
    }
}
