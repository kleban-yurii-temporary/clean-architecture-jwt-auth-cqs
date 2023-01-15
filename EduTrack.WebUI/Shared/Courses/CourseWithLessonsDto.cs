using EduTrack.WebUI.Shared.Dtos.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Courses
{
    public class CourseWithLessonsDto
    {
        public Guid Id { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public int LecturesHours { get; set; }
        public int LecturesCount { get { return LecturesHours / 2; }  }
        public int PracticeHours { get; set; }
        public int PracticeCount { get { return PracticeHours / 2; } }
        public int LaboratoryHours { get; set; }
        public int LaboratoryCount { get { return LaboratoryHours / 2; } }
        public int ConsultationHours { get; set; }
        public int ConsultationCount { get { return (int)ConsultationHours / 2; } }
        public double ExamHours { get; set; }
        public DateTime MaxDate { get; set; }
        public int PracticeGroupsCount { get; set; } = 1;
        public int LabsGroupsCount { get; set; } = 1;
    }
}
