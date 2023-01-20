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
    public class EduYearsRepository : BaseContextRepository, IEduYearsRepository
    {
        public EduYearsRepository(DataContext ctx) : base(ctx) { }

        public async Task<IEnumerable<EduYear>> GetListAsync()
        {
            return await _dbCtx.EduYears.OrderBy(x=> x.Start).ToListAsync();
        }
    }
}
