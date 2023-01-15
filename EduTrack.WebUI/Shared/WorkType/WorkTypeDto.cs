using EduTrack.WebUI.Shared.Dtos.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.WorkTypes
{
    public class WorkTypeDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ShortTitle { get; set; }
        public int Order { get; set; }
        public double PerStudentNorm { get; set; }
        public LessonTypeDto LessonType { get; set; }

        public static WorkTypeDto Empty
        {
            get
            {
                return new WorkTypeDto
                {
                    Id = Guid.Empty,
                    LessonType = LessonTypeDto.None,
                    Order = 0,
                    Title = "- не вказано -"
                };
            }
        }

    }
}
