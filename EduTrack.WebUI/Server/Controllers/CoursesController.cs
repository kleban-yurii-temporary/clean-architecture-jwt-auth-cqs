using EduTrack.Application.Courses.Commands.CreateCourse;
using EduTrack.Application.Courses.Queries.GetCourses;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Courses;
using EduTrack.WebUI.Shared.Users;
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
    public class CoursesController : ApiController
    {
        public CoursesController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(Shared.ApiHelpers.ApiUrl.Courses.Teacher.Default)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> GetTeachersListAsync()
        {
            var result = await _mediator.Send(new GetTeacherCoursesQuery((Guid)CurrentUserId));

            return result.Match(
                result => Ok(_mapper.Map<List<CourseReadDto>>(result)),
                errors => Problem(errors));
        }

        [HttpPost(Shared.ApiHelpers.ApiUrl.Courses.Teacher.Default)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> CreateAsync(CourseCreateTypeEnum type)
        {
            if (type == CourseCreateTypeEnum.Course)
            {
                var result = await _mediator.Send(new CreateCourseCommand((Guid)CurrentUserId));

                return result.Match(
                    result => Ok(result),
                    errors => Problem(errors));
            }

            if (type == CourseCreateTypeEnum.OtherCourse)
            {
                var result = await _mediator.Send(new CreateCourseCommand((Guid)CurrentUserId));

                return result.Match(
                    result => Ok(result),
                    errors => Problem(errors));
            }

            return BadRequest();
        }

        [HttpGet(Shared.ApiHelpers.ApiUrl.Courses.Teacher.DefaultItemServer)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            var result = await _mediator.Send(new GetCourseQuery(id, (Guid)CurrentUserId));

            return result.Match(
                    result => Ok(_mapper.Map<CourseReadDto>(result)),
                    errors => Problem(errors));
        }

        [HttpGet(Shared.ApiHelpers.ApiUrl.Courses.Teacher.DStudentsAndGroupsServer)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> GetCourseWithStudentsAndGroups(Guid id)
        {
            var result = await _mediator.Send(new GetStudentsAndGroupsQuery(id, (Guid)CurrentUserId));

            return result.Match(
                    result => Ok(_mapper.Map<CourseWithGroupsAndStudentsDto>(result)),
                    errors => Problem(errors));
        }

        [HttpPut(Shared.ApiHelpers.ApiUrl.Courses.Teacher.Default)]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> UpdateAsync(CourseUpdateDto course)
        {
            var result = await _mediator.Send(new UpdateCourseCommand(
                _mapper.Map<Course>(course), (Guid)CurrentUserId));

            return result.Match(
                    result => Ok(result),
                    errors => Problem(errors));
        }

       
    }
}
