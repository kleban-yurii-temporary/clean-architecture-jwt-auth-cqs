using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Localization;
using ErrorOr;

namespace EduTrack.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error NotFound
               = Error.Conflict("User.NotFound",
                   description: Lang_Errors.User_NotFound);

            public static Error RoleNotFound
               = Error.Conflict("User.Role.NotFound",
                   description: Lang_Errors.UserRole_NotFound);

            public static Error NotApproved
               = Error.Conflict("User.NotApproved",
                   description: Lang_Errors.User_NotApproved);
        }
    }
}
