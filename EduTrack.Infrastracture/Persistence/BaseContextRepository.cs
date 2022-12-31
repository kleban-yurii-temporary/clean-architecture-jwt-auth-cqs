using EduTrack.Infrastracture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Persistence
{
    public abstract class BaseContextRepository
    {
        protected readonly DataContext _dbCtx;

        protected BaseContextRepository(DataContext dbCtx) 
        {
            _dbCtx = dbCtx;
        }

        public async Task SaveAsync()
        {
            await _dbCtx.SaveChangesAsync();
        }
    }
}
