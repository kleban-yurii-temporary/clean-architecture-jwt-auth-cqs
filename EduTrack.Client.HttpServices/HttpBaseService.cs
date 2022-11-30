using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public abstract class HttpBaseService
    {
        protected readonly HttpClient _httpClient;
        public HttpBaseService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }
    }
}
