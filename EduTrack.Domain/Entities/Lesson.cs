using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Lesson : BaseNamedEntity
    {
        public int Num { get; set; } = 1;
        public Course? Course { get; set; }
        public SubGroup? SubGroup { get; set; }
        public DateTime DocumentedDate { get; set; }
        public DateTime RealDate { get; set; }
        public long SubGroupUniteCode { get; set; }

        [ForeignKey("WorkType")]
        public Guid WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }
        public LessonType LessonType { get; set; } = LessonType.None;
        public GradeType GradeType { get; set; } = GradeType.Simple;
        public double MaxGrade { get; set; }
        public bool Unlist { get; set; }

        public string MeetingUrl { get; set; } = string.Empty;
        public string MeetingUrlDetails { get; set; } = string.Empty;
        public virtual ICollection<GradeAndPresense> GradesAndPresenses { get; set; } = new List<GradeAndPresense>();
        public virtual ICollection<ComplexGradeItemHeader> ComplexGradeItems { get; set; } = new List<ComplexGradeItemHeader>();
    }

    public class ComplexGradeItemHeader : BaseNamedEntity
    {
        public double MaxGrade { get; set; }
    }

    public enum GradeType
    {
        Simple = 1,
        Complex = 2
    }

    public enum LessonType
    {
        None = -1,
        Lecture = 1,
        Pactice = 2,
        Laboratory = 3,
        Consultation = 4,
        Exam = 5
    }
}
