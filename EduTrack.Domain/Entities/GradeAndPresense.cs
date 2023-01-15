using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace EduTrack.Domain.Entities
{
    public class GradeAndPresense : BaseEntity
    {
        public Lesson Lesson { get; set; }
        public StudentRecord Student {get;set;}
        public virtual ICollection<ComplexGradeItem> ComplexGradeItems { get; set; } = new List<ComplexGradeItem>();
        public bool IsPresent { get; set; }
        [NotMapped]
        public double TotalGrade { 
            get { 
                if(ComplexGradeItems.Any())
                    return ComplexGradeItems.Sum(x=> x.Grade);
                return Grade;
            } 
        }
        public double Grade { get; set; }
    }

    public class ComplexGradeItem : BaseEntity
    {
        public double Grade { get; set; }
    }
}