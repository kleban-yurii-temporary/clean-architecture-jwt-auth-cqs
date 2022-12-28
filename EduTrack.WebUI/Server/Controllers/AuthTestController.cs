using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ApiController
    {
        public AuthTestController(IMediator mediator, IMapper mapper) 
            : base(mediator, mapper)  {}

        [HttpGet("auth-only")]
        [Authorize]
        public IActionResult AuthOnlyTest()
        {
            return Ok("Ok: auth-only");
        }

        [HttpGet("teacher")]
        [Authorize(Roles = "teacher")]
        public IActionResult TeacherTest()
        {
            return Ok("Ok: teacher");
        }

        [HttpGet("student")]
        [Authorize(Roles = "student")]
        public IActionResult StudentTest()
        {
            return Ok("Ok: student");
        }

    }
}
