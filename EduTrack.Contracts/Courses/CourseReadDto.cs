using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Contracts.Courses
{
    public record CourseReadDto(
        Guid Id,
        string Name,
        string Desription,
        bool IsActive);    
}
