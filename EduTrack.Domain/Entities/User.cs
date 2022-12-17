using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Email { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<Course>? TeacherCourses { get; set; }
        public virtual ICollection<Group>? StudentGroups { get; set; }
        public string? Role { get; set; } = "student";
        public bool IsApproved { get; set; } = false;

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
