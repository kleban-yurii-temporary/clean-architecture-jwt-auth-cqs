using EduTrack.WebUI.Shared.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Courses
{
    public class CourseReadDto
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string ShortTitle { get; set; }

        public EduYearDto EduYear { get; set; }
        public Guid EduYearId { get; set; }
        public string GroupCode { get; set; }
        public int Semestr { get; set; }
        public int StudentsCount { get; set; }
        public int StudentsCountActualy { get; set; }
        public int LecturesHours { get; set; }
        public int LecturesActualy { get; set; }
        public int PracticeHours { get; set; }
        public int PracticeActualy { get; set; }
        public int LaboratoryHours { get; set; }
        public int LaboratoryActualy { get; set; }
        public double CounsultationHours { get; set; }
        public double CounsultationHoursActualy { get; set; }
        public double ExamHours { get; set; }
        public double ExamHoursActualy { get; set; }
        public Guid CourseTypeId { get; set; }
        public int PracticeGroupsCount { get; set; } 
        public int LabsGroupsCount { get; set; }
        public int GroupsCount { get; set; }
        public int GroupsActualy { get; set; }
        public bool IsActive { get; set; }
        public DateTime? MaxDate { get; set; }
    }
}
