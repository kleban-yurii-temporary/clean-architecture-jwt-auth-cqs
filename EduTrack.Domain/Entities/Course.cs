using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Course : BaseNamedEntity
    {
        public string? EduYear { get; set; }
        public string? Desription { get; set; }
        public Group? Group { get; set; }
        public User? Teacher { get; set; }
    }
}
