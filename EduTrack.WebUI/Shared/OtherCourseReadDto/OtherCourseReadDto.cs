using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Courses
{
    public record OtherCourseReadDto(
        Guid Id,
        string Title,
        string EduYear,
        string GroupCode,
        int Semestr,
         int StudentsCount,
         double Hours,
         double HoursActualy,
    bool IsActive);
}
