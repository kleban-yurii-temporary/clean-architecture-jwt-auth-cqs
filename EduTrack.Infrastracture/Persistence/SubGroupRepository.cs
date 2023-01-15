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
    public class SubGroupRepository : BaseContextRepository, ISubGroupsRepository
    {
        public SubGroupRepository(DataContext ctx)
            : base(ctx) { }

        public async Task<SubGroup> CreateAsync(Guid courseId)
        {
            var group = await _dbCtx.SubGroups.AddAsync(new SubGroup
            {
                Title = $"Гр. {_dbCtx.SubGroups.Count(x => x.Course.Id == courseId) + 1}",
                Course = await _dbCtx.Courses.FindAsync(courseId)
            });

            await SaveAsync();

            return group.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            _dbCtx.SubGroups.Remove(await _dbCtx.SubGroups
                .FirstAsync(x => x.Id == id));

            await SaveAsync();

            return true;
        }


        public async Task<SubGroup> GetAsync(Guid id)
        {
            return await _dbCtx.SubGroups
                .Include(x => x.Students)
                .Include(x => x.Course)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SubGroup>> GetListAsync(Guid courseId)
        {
            return await _dbCtx.SubGroups.Where(x => x.Course.Id == courseId).ToListAsync();
        }

        public Guid GetOwnerId(Guid objectId)
        {
            return _dbCtx.SubGroups.Include(x => x.Course).First(x => x.Id == objectId).Course.OwnerId;
        }

        public async Task<SubGroup> UpdateAsync(SubGroup group)
        {
            var updGroup = await _dbCtx.SubGroups.FindAsync(group.Id);
            updGroup.Title = group.Title;
            await SaveAsync();
            return updGroup;
        }


    }
}
