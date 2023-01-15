using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Courses
{
    public class CourseUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? GroupCode { get; set; }
        public string? EduYear { get; set; }
        public string? ShortTitle { get; set; }
        public Guid CourseTypeId { get; set; }
        public int Semestr { get; set; }
        public int StudentsCount { get; set; }
        public int PracticeGroupsCount { get; set; }
        public int LabsGroupsCount { get; set; }
        public bool IsActive { get; set; }
        public double LecturesHours { get; set; }
        public double PracticeHours { get; set; }
        public double LaboratoryHours { get; set; }
        public double ConsultationHours { get; set; }
        public double ExamHours { get; set; }
        public DateTime MaxDate { get; set; }
    }
}
