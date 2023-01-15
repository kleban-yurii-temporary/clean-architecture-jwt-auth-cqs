using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Localization;
using ErrorOr;

namespace EduTrack.Domain.AppErrors
{
    public static partial class Errors
    {
        public static class Course
        {
            public static Error NotFound
               = Error.Conflict("Course.NotFound",
                   description: Lang_Errors.Course_NotFound);

            public static Error AccessDenied
               = Error.Conflict("Course.AccessDenied",
                   description: "");

            public static Error Inactive
               = Error.Conflict("Course.Inactive",
                   description: Lang_Errors.Course_Inactive);

            public static Error StudentExists
               = Error.Conflict("Course.StudentExists",
                   description: Lang_Errors.Course_StudentExists);


            public static Error SubGroupHasStudents
              = Error.Conflict("Course.Subgroup.HasStudents",
                  description: Lang_Errors.Course_Subgroup_HasStudents);

        }
    }
}
