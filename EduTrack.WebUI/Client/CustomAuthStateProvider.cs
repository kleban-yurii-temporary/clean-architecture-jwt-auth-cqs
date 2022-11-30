using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace EduTrack.WebUI.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI5MWQxMTJkYi1lZWY5LTQ4OTUtYjE0My1jZGM3ODVkNWE0NDEiLCJnaXZlbl9uYW1lIjoiWXVyaWkiLCJmYW1pbHlfbmFtZSI6IktsZWJhbiIsImp0aSI6ImFmMDU1ODFmLTFlNmYtNGZjZi05OTFhLTFiNmI3YWI4OGQ1NyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InN0dWRlbnQiLCJleHAiOjE2Njk3OTg5NjQsImlzcyI6IkVkdVRyYWNrQXBwIiwiYXVkIjoiRWR1VHJhY2tBcHAifQ.J0c0ZY1sR0XH4HTmrvfXwnLwdtRiOGUDfU7W1gNpwk0";

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            var user = new ClaimsPrincipal(identity);

            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }


    }
}
