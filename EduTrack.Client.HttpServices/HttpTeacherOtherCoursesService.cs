using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpTeacherOtherCoursesService : HttpBaseService
    {
        public HttpTeacherOtherCoursesService(HttpClient httpClient) 
            : base(httpClient)  {}

        public async Task<IEnumerable<OtherCourseReadDto>> GetListAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OtherCourseReadDto>>(Shared.ApiHelpers.ApiUrl.OtherCourses.Teacher.All);
        }
    }
}
