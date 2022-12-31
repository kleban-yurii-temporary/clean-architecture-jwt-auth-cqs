using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Specialities.Queries.GetSpecialities
{
    public class GetSpecialitiesQueryHandler : IRequestHandler<GetSpecialitiesQuery, IEnumerable<Speciality>>
    {
        private readonly ISpecialityRepository specialityRepository;

        public GetSpecialitiesQueryHandler(ISpecialityRepository specialityRepository)
        {
            this.specialityRepository = specialityRepository;
        }

        public async Task<IEnumerable<Speciality>> Handle(GetSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await specialityRepository.GetAllAsync();
        }
    }
}
