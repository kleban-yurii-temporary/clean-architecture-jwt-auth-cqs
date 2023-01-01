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
        string EduYear,
        string GroupCode,
        int Semestr,
         int StudentsCount,
         int StudentsCountActualy,
          int LecturesHours,
          int LecturesActualy,
     int PracticeHours,
      int PracticeActualy,
     int LaboratoryHours,
      int LaboratoryActualy,

    int GroupsCount,
    bool IsActive);
}
