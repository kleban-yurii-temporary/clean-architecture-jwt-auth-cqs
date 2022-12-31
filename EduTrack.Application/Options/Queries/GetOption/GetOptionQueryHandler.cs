using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.AppErrors;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Specialities.Queries.GetOptions
{
    public class GetOptionQueryHandler : IRequestHandler<GetOptionQuery, ErrorOr<Option>>
    {
        private readonly IOptionsRepository optionsRepository;

        public GetOptionQueryHandler(IOptionsRepository optionsRepository)
        {
            this.optionsRepository = optionsRepository;
        }

        public async Task<ErrorOr<Option>> Handle(GetOptionQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (!await optionsRepository.AnyByKeyAsync(request.Key, request.UserId))
            {
                return Errors.Options.NotFound(request.Key);
            }

            return await optionsRepository.GetByKeyAsync(request.Key, request.UserId);
        }
    }
}
