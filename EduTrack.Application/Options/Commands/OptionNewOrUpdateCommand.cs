using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Options.Commands
{
    public record OptionNewOrUpdateCommand(
        string Key, 
        string Value,
        string Group,
        Guid? UserId = null): IRequest<ErrorOr<Option>>;
    
}
