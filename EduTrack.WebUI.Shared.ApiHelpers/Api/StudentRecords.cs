using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.ApiHelpers
{
    public static partial class ApiUrl
    {
        public static class StudentRecords
        {
            public static string DefaultClient(Guid courseId) => $"/api/courses/{courseId}/students";
            public const string DefaultServer = "/api/courses/{courseId}/students";

            public static string UploadDataClient(Guid courseId) => $"/api/courses/{courseId}/students/upload";
            public const string UploadDatatServer = "/api/courses/{courseId}/students/upload";
        }

        public static class SubGroups
        {
            public static string DefaultClient(Guid courseId) => $"/api/courses/{courseId}/subgroups";
            public const string DefaultServer = "/api/courses/{courseId}/subgroups";

            public static string ItemClient(Guid id) => $"/api/subgroups/{id}";
            public const string ItemServer = "/api/subgroups/{id}";
        }
    }
}
