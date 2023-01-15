using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Invites
{
    public record DetailedInviteDto(
        Guid Id, 
        DateTime CreatedOn,
        DateTime ExpiryOn, 
        string CourseTitle,
        Guid CourseId,
        bool IsDeactivated,
        string GroupCode);
}
