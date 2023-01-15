using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class SubGroup : BaseNamedEntity
    {
        [Required]
        public Course? Course { get; set; }       
        public virtual ICollection<StudentRecord>? Students { get; set; } = new List<StudentRecord>();
        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
