using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Dtos.Lessons;
using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpLessonService : HttpBaseService
    {
        public HttpLessonService(HttpClient client)
            : base(client) { }  
        
        public async Task<IEnumerable<LessonDto>> GetList(Guid courseId, LessonTypeDto type)
        {
            var url = EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.CourseClient(courseId, type);
            return await _httpClient.GetFromJsonAsync<IEnumerable<LessonDto>>(url);
        }

        public async Task<ProblemOr<bool>> CreateAsync(Guid courseId, LessonTypeDto type, int count)
        {
            var url = EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.CourseClient(courseId, type);
            var response = await _httpClient.PostAsync($"{url}?count={count}", null);

            return response.IsSuccessStatusCode
                ? new ProblemOr<bool> { Value = await response.Content.ReadFromJsonAsync<bool>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<bool>>();
        }

        public async Task<ProblemOr<bool>> UpdateAsync(LessonDto lesson, bool hasGroups)
        {
            var url = EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.Default;
            Console.WriteLine($"url: {url}");
            var response = await _httpClient.PutAsJsonAsync<LessonDto>($"{url}?hasGroups={hasGroups}", lesson);
            Console.WriteLine($"status: {response.IsSuccessStatusCode}");
            return response.IsSuccessStatusCode
                ? new ProblemOr<bool> { Value = await response.Content.ReadFromJsonAsync<bool>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<bool>>();
        }

        public async Task<ProblemOr<bool>> DeleteAsync(Guid Id, bool hasGroups)
        {
            var url = EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.ItemClient;
            var response = await _httpClient.DeleteAsync($"{url}?isgrouped={hasGroups}");

            return response.IsSuccessStatusCode
                ? new ProblemOr<bool> { Value = await response.Content.ReadFromJsonAsync<bool>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<bool>>();
        }
    }
}
