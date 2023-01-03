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
            course.MaxDate = DateTime.Now.Month > 6 
                ? new DateTime(DateTime.Now.Year, 12, 25) 
                : new DateTime(DateTime.Now.Year + 1, 6, 25);

            var itm = await _dbCtx.Courses.AddAsync(course);
            await SaveAsync();
            return itm.Entity.Id;
        }

        public async Task<Course> GetAsync(Guid id)
        {
            return await _dbCtx.Courses
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetListAsync()
        {
            return await _dbCtx.Courses.ToListAsync();
        }
    }
}
