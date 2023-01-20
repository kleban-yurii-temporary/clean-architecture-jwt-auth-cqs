using EduTrack.WebUI.Shared.Dtos.SubGroups;
using EduTrack.WebUI.Shared.Dtos.WorkTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Lessons
{
    public class LessonDto 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int Num { get; set; }
        public DateTime DocumentedDate { get; set; }
        public DateTime RealDate { get; set; }
        public long SubGroupUniteCode { get; set; }
        public WorkTypeDto WorkType { get; set; }
        public double MaxGrade { get; set; }
        public string MeetingUrl { get; set; } = string.Empty;
        public string MeetingUrlDetails { get; set; } = string.Empty;
        public List<SubGroupLessonDate> GroupDates { get; set; } = new List<SubGroupLessonDate>();
    }

    public class SubGroupLessonDate
    {
        public SubGroupDto SubGroup { get; set; }
        public DateTime DocumentedDate { get; set; }
        public DateTime RealDate { get; set; }
        public int Num { get; set; }
    }

    public enum GradeTypeDto
    {
        Simple = 1,
        Complex = 2
    }

    public enum LessonTypeDto
    {
        None = -1,
        Lecture = 1,
        Pactice = 2,
        Laboratory = 3,
        Consultation = 4,
        Exam = 5
    }
}
