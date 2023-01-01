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
    public class CourseTypeRepository : BaseContextRepository, ICourseTypeRepository
    {
        public CourseTypeRepository(DataContext ctx)
            : base(ctx) {}
             
        public async Task<IEnumerable<CourseType>> GetListAsync()
        {
            return await _dbCtx.CourseTypes.ToListAsync();
        }
    }
}
