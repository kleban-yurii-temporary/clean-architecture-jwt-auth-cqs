using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Dtos.Invites;
using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpStudentRecordService : HttpBaseService
    {
        public HttpStudentRecordService(HttpClient httpClient)
            : base(httpClient) { }
        
        public async Task<ProblemOr<StudentRecordReadDto>> CreateAsync(StudentRecordCreateDto record, Guid courseId)
        {
            var url = Shared.ApiHelpers.ApiUrl.StudentRecords.DefaultClient(courseId);
            var response = await _httpClient.PostAsJsonAsync(url, record);

            return response.IsSuccessStatusCode
                ? new ProblemOr<StudentRecordReadDto> { Value = await response.Content.ReadFromJsonAsync<StudentRecordReadDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<StudentRecordReadDto>>();
        }

        public async Task<ProblemOr<StudentRecordReadDto>> UpdateAsync(StudentRecordReadDto record, Guid courseId)
        {
            var url = Shared.ApiHelpers.ApiUrl.StudentRecords.DefaultClient(courseId);
            var response = await _httpClient.PutAsJsonAsync(url, record);
           
            return response.IsSuccessStatusCode
                ? new ProblemOr<StudentRecordReadDto> { Value = await response.Content.ReadFromJsonAsync<StudentRecordReadDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<StudentRecordReadDto>>();
        }
    }
}
