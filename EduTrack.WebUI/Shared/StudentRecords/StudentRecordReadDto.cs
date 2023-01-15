using EduTrack.WebUI.Shared.Dtos.SubGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.StudentRecords
{
    public class StudentRecordReadDto
    {
        public Guid Id { get; set; }

        [Required]
        public string? FirstName { get; set; } = "-";
        
        [Required]
        public string? LastName { get; set; } = "-";
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = "e@mail.demo";

        public SubGroupDto SubGroup { get; set; } = new SubGroupDto { Id = Guid.Empty, Title = "" };
    }

    public record StudentRecordCreateDto(string FirstName, string LastName, string Email);
}
