using EduTrack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Options.Queries.GetOptions
{
    public record GetOptionsQuery(Guid? userId, bool OwnOnly) : IRequest<IEnumerable<Option>>;
}
