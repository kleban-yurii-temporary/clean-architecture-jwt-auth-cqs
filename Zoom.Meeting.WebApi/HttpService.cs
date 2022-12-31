using System.ComponentModel.Design;
using System.Net.Http;

namespace Zoom.Meeting.WebApi
{

    public class HttpService
    {
        private readonly HttpClient httpClient;

        public HttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Get(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await responseHTTP.Content.ReadAsStringAsync();
                return response;
            }
            else
            {
                return await responseHTTP.Content.ReadAsStringAsync();
            }
        }

        public string GetHost()
        {
            return httpClient.BaseAddress.ToString();
        }
    }
}


