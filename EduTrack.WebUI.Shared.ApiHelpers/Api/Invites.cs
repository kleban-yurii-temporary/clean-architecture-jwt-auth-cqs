using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.ApiHelpers
{
    public static partial class ApiUrl
    {
        public static class Invites
        {
            public const string All = "/api/courses/{courseId}/invites";
            public const string PublicDetails = "/api/invites/{id}/preview";
            public const string Create = "/api/courses/{courseId}/invites";
            public const string Update = "/api/courses/{courseId}/invites";
            public const string Delete = "/api/courses/{courseId}/invites";
            
        }
    }
}
