using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.EduYears.Queries;
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
using static EduTrack.Domain.AppErrors.Errors;

namespace EduTrack.Application.Invites.Queries.GetInvites
{
    public class GetEduYearsQueryHandler : IRequestHandler<GetEduYearsQuery, IEnumerable<EduYear>>
    {
        private readonly IEduYearsRepository eduYearsRepository;
        public GetEduYearsQueryHandler(IEduYearsRepository eduYearsRepository)
        {
            this.eduYearsRepository = eduYearsRepository;
        }

        public async Task<IEnumerable<EduYear>> Handle(GetEduYearsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return await eduYearsRepository.GetListAsync();
        }
    }
}
