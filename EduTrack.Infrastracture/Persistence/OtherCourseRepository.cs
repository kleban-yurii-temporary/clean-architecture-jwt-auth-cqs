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
    public class OtherCourseRepository : BaseContextRepository, IOtherCourseRepository
    {
        public OtherCourseRepository(DataContext ctx)
            : base(ctx) { }

        public async Task<Guid> AddAsync(OtherCourse course)
        {
            var itm = await _dbCtx.OtherCourses.AddAsync(course);
            await SaveAsync();
            return itm.Entity.Id;
        }

        public Task<OtherCourse> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OtherCourse>> GetListAsync()
        {
            return await _dbCtx.OtherCourses.ToListAsync();
        }

        public Guid GetOwnerId(Guid objectId)
        {
            return _dbCtx.OtherCourses.First(x => x.Id == objectId).OwnerId;
        }
    }
}
