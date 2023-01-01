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
        public CourseType? Type { get; set; }

        [ForeignKey("CourseType")]
        public Guid CourseTypeId { get; set; }
        public int Semestr { get; set; }
        public int StudentsCount { get; set; }
        public int GroupsCount { get; set; }
        public string? GroupCode { get; set; }
        public string? EduYear { get; set; }
        public bool IsActive { get; set; }
        public int LecturesHours { get; set; }
        public int PracticeHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int ConsultationHours { get; set; }
       
        public User? Owner { get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        public virtual ICollection<WorkType> OtherWorkTypes { get; set; } = new HashSet<WorkType>();


        // public Group? Group { get; set; }
        // public User? Teacher { get; set; }
    }
}
