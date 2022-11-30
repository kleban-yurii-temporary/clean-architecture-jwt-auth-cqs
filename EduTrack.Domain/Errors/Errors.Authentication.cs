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
        public static class Authentication
        {
            public static Error DuplicateEmail
                = Error.Conflict("Authentication.DuplicateEmail",
                    description: Lang_Errors.Authentication_DuplicateEmail);          

            public static Error InvalidPassword
               = Error.Custom(401, "Authentication.InvalidPassword",
                   description: Lang_Errors.Authentication_InvalidPassword);
        }
    }
}
