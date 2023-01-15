using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Dtos.Invites;
using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using EduTrack.WebUI.Shared.Dtos.SubGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpSubGroupService : HttpBaseService
    {
        public HttpSubGroupService(HttpClient httpClient)
            : base(httpClient) { }
        
        public async Task<ProblemOr<SubGroupDto>> CreateAsync(Guid courseId)
        {
            var url = Shared.ApiHelpers.ApiUrl.SubGroups.DefaultClient(courseId);
            var response = await _httpClient.PostAsJsonAsync<SubGroupDto>(url, new SubGroupDto());

            return response.IsSuccessStatusCode
                ? new ProblemOr<SubGroupDto> { Value = await response.Content.ReadFromJsonAsync<SubGroupDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<SubGroupDto>>();
        }
        
        public async Task<ProblemOr<SubGroupDto>> UpdateAsync(SubGroupDto group, Guid courseId)
        {
            var url = Shared.ApiHelpers.ApiUrl.SubGroups.DefaultClient(courseId);
    
            var response = await _httpClient.PutAsJsonAsync(url, group);

            return response.IsSuccessStatusCode
                ? new ProblemOr<SubGroupDto> { Value = await response.Content.ReadFromJsonAsync<SubGroupDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<SubGroupDto>>();
        }

        public async Task<ProblemOr<bool>> DeleteAsync(Guid id)
        {
            var url = Shared.ApiHelpers.ApiUrl.SubGroups.ItemClient(id);

            var response = await _httpClient.DeleteAsync(url);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return response.IsSuccessStatusCode
                ? new ProblemOr<bool> { Value = await response.Content.ReadFromJsonAsync<bool>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<bool>>();
        }

        public async Task<IEnumerable<SubGroupDto>> GetListAsync(Guid courseId)
        {
            var url = Shared.ApiHelpers.ApiUrl.SubGroups.DefaultClient(courseId);
            return await _httpClient.GetFromJsonAsync<IEnumerable<SubGroupDto>>(url);
        }
    }
}
