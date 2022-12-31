using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Options.Queries.GetOptions
{
    public record GetOptionQuery(string Key, Guid? UserId = null) : IRequest<ErrorOr<Option>>;
}
