using EduTrack.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(Array.Empty<Course>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok(Array.Empty<Course>());
        }
    }
}
