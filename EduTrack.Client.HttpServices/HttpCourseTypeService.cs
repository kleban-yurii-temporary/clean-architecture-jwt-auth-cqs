using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpCourseTypeService : HttpBaseService
    {
        public HttpCourseTypeService(HttpClient httpClient)
            : base(httpClient) { }

        public async Task<List<CourseTypeDto>> GetCourseTypesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CourseTypeDto>>(ApiUrl.Courses.Types);
        }
    }
}
