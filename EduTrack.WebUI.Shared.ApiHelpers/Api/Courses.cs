using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.ApiHelpers
{
    public static partial class ApiUrl
    {
        public static class Courses
        {
            public static class Teacher
            {
                public const string Default = "/api/teacher/courses";

                public static string DefaultItemClient(Guid id) => $"/api/teacher/courses/{id}";
                public const string DefaultItemServer = "/api/teacher/courses/{id}";

                public static string StudentsAndGroupsClient(Guid id) => $"/api/teacher/courses/{id}/students";
                public const string DStudentsAndGroupsServer = "/api/teacher/courses/{id}/students";
            }

            public const string Types = "/api/coursetypes";

            public const string EduYears = "/api/eduyears";
        }

        public static class OtherCourses
        {
            public static class Teacher
            {
                public const string All = "/api/teacher/ocourses";
                public const string Item = "/api/teacher/ocourses/{id}";
                public const string Create = "/api/teacher/ocourses";
            }
        }
    }
}
