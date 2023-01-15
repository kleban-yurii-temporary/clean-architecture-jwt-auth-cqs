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
    public record UpdateSubGroupCommand(SubGroup Group) 
        : IRequest<ErrorOr<SubGroup>>;
}
