using EduTrack.Application.CheckRoleAccesss.Queries.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.CheckRoleAccesss.Queries.IsEditAccessAllowed
{
    public record IsEditAccessAllowedQuery(Guid Id, Guid UserId, EditAccessObjectType accessType) : IRequest<ErrorOr<bool>>;
    
}
