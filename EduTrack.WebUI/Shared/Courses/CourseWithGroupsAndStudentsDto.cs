using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using EduTrack.WebUI.Shared.Dtos.SubGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Courses
{
    public class CourseWithGroupsAndStudentsDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public IEnumerable<StudentRecordReadDto> Students { get; set; }
        public int StudentsCount { get; set; }
        public IEnumerable<SubGroupDto> SubGroups { get; set; }
        public int GroupsCount { get; set;}
    }
}
