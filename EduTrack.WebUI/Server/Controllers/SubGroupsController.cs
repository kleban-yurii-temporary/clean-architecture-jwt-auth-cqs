using EduTrack.Application.Courses.Queries.GetCourses;
using EduTrack.Application.StudentRecords.Commands.CreateStudentRecord;
using EduTrack.Application.SubGroups.Queries.GetSubGroupsList;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using EduTrack.WebUI.Shared.Dtos.SubGroups;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGroupsController : ApiController
    {
        public SubGroupsController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpGet(ApiUrl.SubGroups.DefaultServer)]
        public async Task<IActionResult> GetListAsync(Guid courseId)
        {
            var result = await _mediator.Send(new GetSubGroupsListQuery(courseId));
            return Ok(result);
        }

        [HttpPost(ApiUrl.SubGroups.DefaultServer)]
        public async Task<IActionResult> CreateAsync(Guid courseId)
        {
            var result = await _mediator.Send(new CreateSubGroupCommand(courseId, (Guid)CurrentUserId));

            return result.Match(
                    result => Ok(_mapper.Map<SubGroupDto>(result)),
                    errors => Problem(errors));
        }

        [HttpPut(ApiUrl.SubGroups.DefaultServer)]
        public async Task<IActionResult> UpdateAsync(Guid courseId, SubGroupDto subGroup)
        {
            var result = await _mediator.Send(new UpdateSubGroupCommand(_mapper.Map<SubGroup>(subGroup)));

            return result.Match(
                    result => Ok(_mapper.Map<SubGroupDto>(result)),
                    errors => Problem(errors));
        }

        [HttpDelete(ApiUrl.SubGroups.ItemServer)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _mediator.Send(new DeleteSubGroupCommand(id, (Guid)CurrentUserId));

            return result.Match(
                    result => Ok(result),
                    errors => Problem(errors));
        }
    }
}
