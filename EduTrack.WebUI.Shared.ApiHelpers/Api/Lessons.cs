using EduTrack.WebUI.Shared.Dtos.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Helpers.Api
{
    public static partial class ApiUrl
    {
        public static class Lessons
        {
            public static string CourseClient(Guid courseId, LessonTypeDto type) => $"/api/courses/{courseId}/lessons/{type}";
            public const string CourseServer = "/api/courses/{courseId}/lessons/{type}";

            public const string Default = $"/api/lessons/";
            public static string ItemClient(Guid id) => $"/api/lessons/{id}";
            public const string ItemServer = "/api/lessons/{id}";
        }
    }
}
