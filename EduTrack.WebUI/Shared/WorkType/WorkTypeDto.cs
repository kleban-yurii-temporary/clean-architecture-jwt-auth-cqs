using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.WorkTypes
{
    public record WorkTypeDto(
        Guid Id, 
        string Title,
        string ShortTitle, 
        int Order,
        double PerStudentNorm);
}
