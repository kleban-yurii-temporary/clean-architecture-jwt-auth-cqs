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
        public string? EduYear { get; set; }
        public string? Desription { get; set; }
        public bool IsActive { get; set; }
        public int LecturesHours { get; set; }
        public int PracticeHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int ConsultationHours { get; set; }
        public int ExamHours { get; set; }

        [ForeignKey("Speciality")]
        public Guid SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }

        // public Group? Group { get; set; }
        // public User? Teacher { get; set; }
    }
}
