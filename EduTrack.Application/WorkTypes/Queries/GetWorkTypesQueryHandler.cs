using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain.AppErrors;
using EduTrack.Application.WorkTypes.Queries;

namespace EduTrack.Application.Users.Queries.GetUser
{
    public class GetWorkTypesQueryHandler : IRequestHandler<GetWorkTypesQuery, IEnumerable<WorkType>>
    {
        private readonly IWorkTypesRepository workTypesRepository;

        public GetWorkTypesQueryHandler(IWorkTypesRepository workTypesRepository)
        {
            this.workTypesRepository = workTypesRepository;
        }

        public async Task<IEnumerable<WorkType>> Handle(GetWorkTypesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await workTypesRepository.GetAllAsync(); 
        }
    }
}
