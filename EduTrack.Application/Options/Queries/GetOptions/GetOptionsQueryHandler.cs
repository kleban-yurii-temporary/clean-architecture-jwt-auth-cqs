using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Specialities.Queries.GetOptions
{
    public class GetOptionsQueryHandler : IRequestHandler<GetOptionsQuery, IEnumerable<Option>>
    {
        private readonly IOptionsRepository optionsRepository;

        public GetOptionsQueryHandler(IOptionsRepository optionsRepository)
        {
            this.optionsRepository = optionsRepository;
        }

        public async Task<IEnumerable<Option>> Handle(GetOptionsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var options = await optionsRepository.GetAllAsync((Guid)request.userId, request.OwnOnly);
            return options;
        }
    }
}
