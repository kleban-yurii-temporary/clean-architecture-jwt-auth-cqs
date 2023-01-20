using EduTrack.WebUI.Shared.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpEduYearService : HttpBaseService
    {
        public HttpEduYearService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<EduYearDto>> GetListAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<EduYearDto>>(Shared.ApiHelpers.ApiUrl.Courses.EduYears);
        }

    }
}
