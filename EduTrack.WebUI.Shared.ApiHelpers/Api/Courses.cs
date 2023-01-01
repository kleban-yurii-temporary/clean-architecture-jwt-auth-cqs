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
                public const string All = "/api/teacher/courses";
                public const string Item = "/api/teacher/courses/{id}";
                public const string Create = "/api/teacher/courses";
            } 
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
