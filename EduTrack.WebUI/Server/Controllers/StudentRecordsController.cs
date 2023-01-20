using EduTrack.Application.Courses.Queries.GetCourses;
using EduTrack.Application.StudentRecords.Commands.CreateStudentRecord;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.ApiHelpers;
using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRecordsController : ApiController
    {
        private readonly IWebHostEnvironment env;

        public StudentRecordsController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [HttpPost(ApiUrl.StudentRecords.DefaultServer)]
        public async Task<IActionResult> CreateAsync(Guid courseId, StudentRecordCreateDto record)
        {
            var result = await _mediator.Send(new CreateStudentRecordCommand(
                _mapper.Map<StudentRecord>(record), courseId, (Guid)CurrentUserId));

            return result.Match(
                    result => Ok(_mapper.Map<StudentRecordReadDto>(result)),
                    errors => Problem(errors));
        }

        [HttpPut(ApiUrl.StudentRecords.DefaultServer)]
        public async Task<IActionResult> UpdateAsync(Guid courseId, StudentRecordReadDto record)
        {
            var result = await _mediator.Send(new UpdateStudentRecordCommand(
                _mapper.Map<StudentRecord>(record)));

            return result.Match(
                    result => Ok(_mapper.Map<StudentRecordReadDto>(result)),
                    errors => Problem(errors));
        }

        [HttpPost(ApiUrl.StudentRecords.UploadDatatServer)]
        public async Task<IActionResult> UploadData(Guid courseId, IFormFile file)
        {
            var fileL = file.ContentType;
            return Ok("--");
        }
    }
}
