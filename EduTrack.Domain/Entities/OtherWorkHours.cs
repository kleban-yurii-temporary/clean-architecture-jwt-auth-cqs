using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class OtherWorkHours : BaseEntity
    {
        public double Hours { get; set; }
        public OtherCourse Course { get; set; }
    }
}
