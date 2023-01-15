using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class LessonTime : BaseEntity
    {
        public int Num { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
    }
}
