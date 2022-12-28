using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using EduTrack.Infrastracture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Persistence
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly DataContext _ctx;
        public SpecialityRepository(DataContext ctx) 
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            return await _ctx.Specialities.ToListAsync();
        }
    }
}
