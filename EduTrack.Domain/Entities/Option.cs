using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Option
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required] 
        public string? Key { get; set; }

        [Required]
        public string? Value { get; set; }
        [Required]
        public string? Group { get; set; }

        public bool CantBeRemoved { get; set; } = false;

        public User? Owner { get; set; }

        [NotMapped]
        public bool IsGlobal { get { return Owner is null; } } 


    }
}
