using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class OtherCourse : BaseNamedEntity
    {
        public int Semestr { get; set; }
        public int StudentsCount { get; set; }
        public string? GroupCode { get; set; }
        public EduYear? EduYear { get; set; }
        public bool IsActive { get; set; }
        public WorkType? WorkType { get; set; }
        public double? Hours { get; set; }
        public User? Owner { get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }

        public virtual ICollection<OtherWorkHours> WorkHours { get; set; }
    }
}
