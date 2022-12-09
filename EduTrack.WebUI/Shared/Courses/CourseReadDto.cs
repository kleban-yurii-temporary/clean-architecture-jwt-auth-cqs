using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Courses
{
    public record CourseReadDto(
        Guid Id,
        string Title,
        string Desription,
        string EduYear,
        bool IsActive);
}
