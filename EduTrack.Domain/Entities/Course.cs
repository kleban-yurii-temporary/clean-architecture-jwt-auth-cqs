using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Course : BaseNamedEntity
    {
        public string? GroupCode { get; set; }
        public string? EduYear { get; set; }
        public string? ShortTitle { get; set; } = String.Empty;

        public CourseType? Type { get; set; }

        [ForeignKey("CourseType")]
        public Guid CourseTypeId { get; set; }
        public int Semestr { get; set; } = 1;
        public int StudentsCount { get; set; }

        public int PracticeGroupsCount { get; set; } = 1;
        public int LabsGroupsCount { get; set; } = 1;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = false;
        public double LecturesHours { get; set; }
        public double PracticeHours { get; set; }
        public double LaboratoryHours { get; set; }
        public double ConsultationHours { get; set; }
        public double ExamHours { get; set; }
        public DateTime MaxDate { get; set; } = DateTime.UtcNow.AddMonths(5).Date;
        public User? Owner { get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        public virtual ICollection<WorkType> OtherWorkTypes { get; set; } = new List<WorkType>();
        public virtual ICollection<CourseInvite> Invites { get; set; } = new List<CourseInvite>();
        public virtual ICollection<StudentRecord> Students { get; set; } = new List<StudentRecord>();
        public virtual ICollection<SubGroup> SubGroups { get; set; } = new List<SubGroup>();
        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
}
