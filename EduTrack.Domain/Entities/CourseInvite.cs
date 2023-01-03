using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class CourseInvite : BaseEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ExpiryOn { get; set; } = DateTime.UtcNow.AddDays(10);

        [Required]
        public Course? Course { get; set; }
    }
}
