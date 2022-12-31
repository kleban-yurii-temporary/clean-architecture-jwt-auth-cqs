using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.ApiHelpers
{
    public static partial class ApiUrl
    {
        public static class Zoom
        {
            public static class OAuth
            {
                public const string AuthorizeUrl = "/api/zoom/oauth/authorize_url";
                public const string Redirect = "/api/zoom/oauth/redirect";
            } 
            
            public static class Users 
            {
                public const string Me = "/api/zoom/me";
            }

            public static class Meetings
            {
                public const string All = "/api/zoom/meetings";
            }

            public static class Webinars
            {
                public const string All = "/api/zoom/webinars";
            }

            public static class Recordings
            {
                public const string All = "/api/zoom/recordings";
            }
        }
    }
}
