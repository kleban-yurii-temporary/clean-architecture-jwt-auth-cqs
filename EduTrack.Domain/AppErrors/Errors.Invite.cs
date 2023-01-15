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
        public static class Invite
        {
            public static Error NotFound
               = Error.Conflict("Invite.NotFound",
                   description: Lang_Errors.Invite_NotFound);

            public static Error Expired
               = Error.Conflict("Invite.Expired",
                   description: Lang_Errors.Invite_Expired);

            public static Error Deactivated
               = Error.Conflict("Invite.Deactivated",
                   description: Lang_Errors.Invite_Deactivated);
        }
    }
}
