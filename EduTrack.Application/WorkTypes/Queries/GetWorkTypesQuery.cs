﻿using EduTrack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.WorkTypes.Queries
{
    public record GetWorkTypesQuery() : IRequest<IEnumerable<WorkType>>;
}
