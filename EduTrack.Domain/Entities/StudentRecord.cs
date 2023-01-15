using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class StudentRecord : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Course? Course { get; set; }
        public User? User { get; set; } = null;
        public SubGroup? SubGroup { get; set; }
        public virtual ICollection<GradeAndPresense> GradesAndPresense { get;set; }
    }
}
