using EduTrack.Localization;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.AppErrors
{
    public static partial class Errors
    {
        public static class Options
        {
            public static Error NotFound(string key)
            {
                return Error.Failure("Option.NotFound",
                   description: string.Format(Lang_Errors.Option_NotFound, key));
            }

            public static Error EmptyValue(string key)
            {
                return Error.Failure("Option.EmptyValue",
                   description: string.Format(Lang_Errors.Option_EmptyValue, key));
            }
        }
    }
}
