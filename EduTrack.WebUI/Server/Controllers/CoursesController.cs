﻿using EduTrack.Application.Courses.Queries.GetCourses;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Courses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CoursesController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _mediator.Send(new GetCoursesQuery());

            return result.Match(
                result => Ok(_mapper.Map<List<CourseReadDto>>(result)),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok(Array.Empty<Course>());
        }
    }
}