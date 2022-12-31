using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Zoom.Meeting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : ControllerBase
    {


        public ZoomController()
        {
           
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://google.com");
            return Ok(await response.Content.ReadAsStringAsync());
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            string authUrl = "https://zoom.us/oauth/authorize";

            string client_id = "xcmBTlkyTNGJqIOvupD1A";
            string client_secret = "POgBxWJ4BYxB1nFa0VEQ7tIQQO8ddt71";

            string queryUrl = "---";
            string userState = "";

            string token = "empty";
            HttpClient client = new HttpClient();
            var host = "https://localhost:7087/";
             queryUrl = $"{authUrl}?response_type=code&client_id={client_id}&redirect_uri={host}";

            var resp = await client.GetAsync(queryUrl);

            return Ok(await resp.Content.ReadAsStringAsync());
        }

    }
}
