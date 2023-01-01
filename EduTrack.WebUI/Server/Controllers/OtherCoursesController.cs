using EduTrack.Application.Courses.Queries.GetCourses;
using EduTrack.Application.OtherCourses.Queries.GeTeachertOtherCourses;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Courses;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OtherCoursesController : ApiController
    {
        public OtherCoursesController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(Shared.ApiHelpers.ApiUrl.OtherCourses.Teacher.All)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> GetTeachersListAsync()
        {
            var result = await _mediator.Send(new GetTeacherOtherCoursesQuery((Guid)CurrentUserId));

            return result.Match(
                result => Ok(_mapper.Map<List<OtherCourseReadDto>>(result)),
                errors => Problem(errors));
        }
    }
}
