using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Shared.Dtos.Invites
{
    public record InviteDto(Guid Id, DateTime CreatedOn, DateTime ExpiryOn, bool IsDeactivated);
}
