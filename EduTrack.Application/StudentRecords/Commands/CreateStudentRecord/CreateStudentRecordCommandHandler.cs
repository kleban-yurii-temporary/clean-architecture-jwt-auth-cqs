using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Commands;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.AppErrors;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.StudentRecords.Commands.CreateStudentRecord
{
    public class CreateStudentRecordCommandHandler : IRequestHandler<CreateStudentRecordCommand, ErrorOr<StudentRecord>>
    {
        private readonly IStudentRecordsRepository studentRecordsRepository;
        private readonly ICourseRepository courseRepository;

        public CreateStudentRecordCommandHandler(
            IStudentRecordsRepository studentRecordsRepository,
            ICourseRepository courseRepository)
        {
            this.studentRecordsRepository = studentRecordsRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<StudentRecord>> Handle(CreateStudentRecordCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = await courseRepository.GetAsync(request.CourseId);

            if (course.OwnerId != request.TeacherId) 
                return Errors.Course.AccessDenied;

            var std = await studentRecordsRepository.GetByEmailAndCourseAsync(request.Student.Email, request.CourseId);

            if(std is not null)
                return Errors.Course.StudentExists;

            var newStudent = await studentRecordsRepository.CreateAsync(request.Student, request.CourseId);

            return newStudent;
        }
    }
}
