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
    public class CourseRepository : BaseContextRepository, ICourseRepository
    {
        public CourseRepository(DataContext ctx)
            : base(ctx) {}

        public async Task<Guid> AddAsync(Course course)
        {
            var itm = await _dbCtx.Courses.AddAsync(course);
            await SaveAsync();
            return itm.Entity.Id;
        }

        public Task<Course> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetListAsync()
        {
            return await _dbCtx.Courses.ToListAsync();
        }
    }
}
