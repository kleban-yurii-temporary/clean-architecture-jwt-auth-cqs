using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.ApiHelpers
{
    public static partial class ApiUrl
    {
        public static class Authentication
        {
            public const string Login = "/api/auth/login";
            public const string Register = "/api/auth/reg";
            public const string RefreshToken = "/api/auth/refresh-token";
            public const string Logount = "/api/auth/logout";
        }
    }
}
