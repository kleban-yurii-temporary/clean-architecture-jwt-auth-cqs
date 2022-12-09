using EduTrack.WebUI.Shared.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpCoursesService : HttpBaseService
    {
        public HttpCoursesService(HttpClient httpClient) 
            : base(httpClient)  {}

        public async Task<IEnumerable<CourseReadDto>> GetListAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CourseReadDto>>("/api/courses");
        }
    }
}
