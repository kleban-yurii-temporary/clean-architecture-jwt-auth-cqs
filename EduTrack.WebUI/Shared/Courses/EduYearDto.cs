using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Courses
{
    public class EduYearDto
    {
        public Guid Id { get; set; }

        // [Required]
        // [Range(2022, 2025)]
        // [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed Start")]
        public int Start { get; set; }

        // [Required]
        // [Range(2023, 2025)]
        // [RegularExpression(@"^\d+$", ErrorMessage = "Only numbers allowed End")]
        public int End { get; set; }

        [NotMapped]
        public string Year
        {
            get { return $"{Start}/{End}"; }

        }
    }
}
