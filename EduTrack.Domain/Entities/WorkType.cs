using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class WorkType : BaseNamedEntity
    {
        public string? ShortTitle { get; set; }
        public int Order { get; set; }
        public LessonType LessonType { get; set; } = LessonType.None;
        public double? PerStudentNorm { get; set; }
    }
}
