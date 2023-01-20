using EduTrack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.EduYears.Queries
{
    public record GetEduYearsQuery() : IRequest<IEnumerable<EduYear>>;
    
}
