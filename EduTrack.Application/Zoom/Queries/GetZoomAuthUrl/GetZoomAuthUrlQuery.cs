﻿using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Zoom.Queries.GetAuthUrl
{
    public record GetZoomAuthUrlQuery(Guid UserId) : IRequest<ErrorOr<string>>;
}
