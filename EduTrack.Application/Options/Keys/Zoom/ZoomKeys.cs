using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Options.Keys.Zoom
{
    public static class ZoomApiKeys
    {
        public const string Group = "zoom";

        public static class General
        {
            public const string BaseUrl = "zoom_api_base_url";
            public const string ClientId = "zoom_api_client_id";
            public const string ClientSecret = "zoom_api_client_secret";
        }

        public static class Token
        {
            public const string AccessTokenUrl = "zoom_api_access_token_url";
            public const string AccessTokenType = "zoom_api_access_token_type";
            public const string AccessToken = "zoom_api_access_token";
            public const string RefreshToken = "zoom_api_refresh_token";
            public const string TokenExpiresIn = "zoom_api_token_expires_in";
            public const string Scope = "zoom_api_token_scope";
        }

        public static class Authorize
        {
            public const string AuthUrl = "zoom_api_auth_url";
            public const string RedirectUrl = "zoom_api_redirect_url";
        }

        public static class Users
        {
            public const string Me = "zoom_api_users_me";
            public const string Meetings = "zoom_api_users_me_meetings";
            public const string Webinars = "zoom_api_users_me_webinars";
            public const string Recordings = "zoom_api_users_me_recordings";
        }
    }
}
