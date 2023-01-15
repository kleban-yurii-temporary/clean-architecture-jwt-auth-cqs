using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Invites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpInviteService : HttpBaseService
    {
        public HttpInviteService(HttpClient httpClient)
            : base(httpClient) { }

        public async Task<ProblemOr<IEnumerable<InviteDto>>> GetListAsync(Guid courseId)
        {
            var url = Shared.ApiHelpers.ApiUrl.Invites.All.Replace("{courseId}", courseId.ToString());
            var response =  await _httpClient.GetAsync(url);
            
            return response.IsSuccessStatusCode
               ? new ProblemOr<IEnumerable<InviteDto>> { Value = await response.Content.ReadFromJsonAsync<IEnumerable<InviteDto>>() }
               : await response.Content.ReadFromJsonAsync<ProblemOr<IEnumerable<InviteDto>>>();
        }

        public async Task<ProblemOr<InviteDto>> CreateAsync(Guid courseId)
        {
            var response = await _httpClient.PostAsync(
                Shared.ApiHelpers.ApiUrl.Invites.All.Replace("{courseId}", courseId.ToString()),
                null);

            return response.IsSuccessStatusCode
                ? new ProblemOr<InviteDto> { Value = await response.Content.ReadFromJsonAsync<InviteDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<InviteDto>>();
        }

        public async Task<ProblemOr<DetailedInviteDto>> GetDetailsAsync(Guid id)
        {
            var url = Shared.ApiHelpers.ApiUrl.Invites.PublicDetails.Replace("{id}", id.ToString());
            var response = await _httpClient.GetAsync(url);
            
            return response.IsSuccessStatusCode
                ? new ProblemOr<DetailedInviteDto> { Value = await response.Content.ReadFromJsonAsync<DetailedInviteDto>() }
                : await response.Content.ReadFromJsonAsync<ProblemOr<DetailedInviteDto>>();
        }

    }
}
