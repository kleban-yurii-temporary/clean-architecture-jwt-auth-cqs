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
    public class InviteRepository : BaseContextRepository, IInviteRepository
    {
        public InviteRepository(DataContext ctx)
            : base(ctx) { }

        public async Task<CourseInvite> Create(Guid courseId)
        {
            var invite = await _dbCtx.CourseInvites
                .AddAsync(new CourseInvite
                {
                    Course = await _dbCtx.Courses.FindAsync(courseId),
                    ExpiryOn = DateTime.UtcNow.AddDays(5)
                });

            await SaveAsync();
            return invite.Entity;
        }

        public async Task Delete(Guid id)
        {
            _dbCtx.CourseInvites.Remove(await _dbCtx.CourseInvites.FindAsync(id));
            await SaveAsync();
        }

        public async Task<IEnumerable<CourseInvite>> ListAsync(Guid courseId)
        {
            return await _dbCtx.CourseInvites.Where(x => x.Course.Id == courseId).ToListAsync();
        }

        public async Task<CourseInvite> Update(CourseInvite invite)
        {
            var updInvite = await _dbCtx.CourseInvites.FindAsync(invite.Id);

            updInvite.ExpiryOn = invite.ExpiryOn;

            await SaveAsync();

            return updInvite;
        }

        public async Task<CourseInvite> GetAsync(Guid id)
        {
            return await _dbCtx
                .CourseInvites
                .Include(x=> x.Course)
                .FirstOrDefaultAsync(x=> x.Id == id);
        }

        public Guid GetOwnerId(Guid objectId)
        {
            return _dbCtx.CourseInvites.Include(x => x.Course).First(x => x.Id == objectId).Course.OwnerId;
        }
    }
}
