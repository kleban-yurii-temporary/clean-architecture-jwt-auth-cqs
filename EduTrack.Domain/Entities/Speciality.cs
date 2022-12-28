using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Speciality : BaseNamedEntity
    {
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
