using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Commands;
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

namespace EduTrack.Application.SubGroups.Queries.GetSubGroupsList
{
    public class GetSubGroupsListQueryHandler : IRequestHandler<GetSubGroupsListQuery, IEnumerable<SubGroup>>
    {
        private readonly ISubGroupsRepository subGroupsRepository;

        public GetSubGroupsListQueryHandler(
            ISubGroupsRepository subGroupsRepository)
        {
            this.subGroupsRepository = subGroupsRepository;
        }

        public async Task<IEnumerable<SubGroup>> Handle(GetSubGroupsListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return await subGroupsRepository.GetListAsync(request.CourseId);
        }
    }
}
