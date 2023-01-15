using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Authentication;
using EduTrack.WebUI.Shared.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpTeacherCoursesService : HttpBaseService
    {
        public HttpTeacherCoursesService(HttpClient httpClient) 
            : base(httpClient)  {}

        public async Task<IEnumerable<CourseReadDto>> GetListAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CourseReadDto>>(Shared.ApiHelpers.ApiUrl.Courses.Teacher.Default);
        }

        public async Task<Guid> CreateCourseAsync(CourseCreateTypeEnum type)
        {
            var response = await _httpClient.PostAsJsonAsync<CourseCreateTypeEnum>(Shared.ApiHelpers.ApiUrl.Courses.Teacher.Default, type);
            var str = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }
        public async Task<ProblemOr<CourseReadDto>> GetDetailedAsync(Guid id)
        {
            var url = Shared.ApiHelpers.ApiUrl.Courses.Teacher.DefaultItemClient(id);

            var response = await _httpClient.GetAsync(url);

            return response.IsSuccessStatusCode
                ? new ProblemOr<CourseReadDto> { Value = await response.Content.ReadFromJsonAsync<CourseReadDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<CourseReadDto>>();
        }

        public async Task<ProblemOr<CourseWithGroupsAndStudentsDto>> GetStudentsAndGroupsAsync(Guid id)
        {
            var url = Shared.ApiHelpers.ApiUrl.Courses.Teacher.StudentsAndGroupsClient(id);

            var response = await _httpClient.GetAsync(url);

            return response.IsSuccessStatusCode
                ? new ProblemOr<CourseWithGroupsAndStudentsDto> { Value = await response.Content.ReadFromJsonAsync<CourseWithGroupsAndStudentsDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<CourseWithGroupsAndStudentsDto>>();
        }

        public async Task<ProblemOr<bool>> UpdateCourse(CourseReadDto course)
        {
            var url = Shared.ApiHelpers.ApiUrl.Courses.Teacher.Default;

            var response = await _httpClient.PutAsJsonAsync(url, course);

            return response.IsSuccessStatusCode
                ? new ProblemOr<bool> { Value = await response.Content.ReadFromJsonAsync<bool>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<bool>>();
        }

    }
}
