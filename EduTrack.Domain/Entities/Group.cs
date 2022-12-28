using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Group : BaseNamedEntity
    {
        public string? Desription { get; set; } = string.Empty;
        public Group? Parent { get; set; }
        public virtual ICollection<Group>? SubGroups { get; }        
        public virtual ICollection<User>? Students { get; set; }
        public Course? Course { get; set; }

        [NotMapped]
        public bool IsRoot => Parent is null;
    }
}
