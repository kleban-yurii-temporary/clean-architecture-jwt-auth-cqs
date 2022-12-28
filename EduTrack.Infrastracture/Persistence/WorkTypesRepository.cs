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
    public class WorkTypesRepository : IWorkTypesRepository
    {
        private DataContext _ctx;

        public WorkTypesRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<WorkType>> GetAllAsync()
        {
            return await _ctx.WorkTypes.OrderBy(x=> x.Order).ToListAsync();
        }
    }
}
