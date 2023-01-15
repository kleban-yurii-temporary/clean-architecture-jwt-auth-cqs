using EduTrack.Application.Lessons.Commands.CreateLessons;
using EduTrack.Application.Lessons.Commands.DeleteLesson;
using EduTrack.Application.Lessons.Commands.UpdateLesson;
using EduTrack.Application.Lessons.Queries.GetLessons;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Dtos.Invites;
using EduTrack.WebUI.Shared.Dtos.Lessons;
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
    public class LessonsController : ApiController
    {
        public LessonsController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.CourseServer)]
        public async Task<IEnumerable<LessonDto>> GetLessonsAsync(Guid courseId, LessonTypeDto type)
        {
            var result = await _mediator.Send(new GetLessonsQuery(courseId, _mapper.Map<LessonType>(type), (Guid)CurrentUserId));
            return _mapper.Map<IEnumerable<LessonDto>>(result);
        }

        [HttpPost(EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.CourseServer)]
        public async Task<IActionResult> CreateLessonsAsync(Guid courseId, LessonTypeDto type, int count)
        {
            var result = await _mediator.Send(new CreateLessonsCommand(courseId, count, _mapper.Map<LessonType>(type), (Guid)CurrentUserId));
            
            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpPut(EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.Default)]
        public async Task<IActionResult> UpdateAsync(LessonDto lesson, bool hasGroups)
        {
            var result = await _mediator.Send(new UpdateLessonCommand(_mapper.Map<Lesson>(lesson), hasGroups, (Guid)CurrentUserId));

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpDelete(EduTrack.WebUI.Shared.Helpers.Api.ApiUrl.Lessons.ItemServer)]
        public async Task<IActionResult> DeleteAsync(Guid id, bool isGrouped)
        {
            var result = await _mediator.Send(new DeleteLessonCommand(id, isGrouped, (Guid)CurrentUserId));

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
