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
    public class UpdateStudentRecordCommandHandler : IRequestHandler<UpdateStudentRecordCommand, ErrorOr<StudentRecord>>
    {
        private readonly IStudentRecordsRepository studentRecordsRepository;

        public UpdateStudentRecordCommandHandler(
            IStudentRecordsRepository studentRecordsRepository,
            ICourseRepository courseRepository)
        {
            this.studentRecordsRepository = studentRecordsRepository;
        }

        public async Task<ErrorOr<StudentRecord>> Handle(UpdateStudentRecordCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return await studentRecordsRepository.UpdateAsync(request.Student); 
        }
    }
}
