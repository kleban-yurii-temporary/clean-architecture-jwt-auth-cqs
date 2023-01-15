using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.SubGroups
{
    public class SubGroupDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        [Required]
        public string Title { get; set; } = "- без групи -";
    }
}
