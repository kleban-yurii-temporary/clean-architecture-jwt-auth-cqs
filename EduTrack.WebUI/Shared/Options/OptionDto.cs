using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Options
{
    public record OptionDto(string Key, string Value, string Group, bool CantBeRemoved);
}
