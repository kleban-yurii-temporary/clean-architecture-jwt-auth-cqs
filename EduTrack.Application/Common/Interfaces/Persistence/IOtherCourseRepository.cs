using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface IOtherCourseRepository : ICourseOwner<Guid>
    {
        Task<IEnumerable<OtherCourse>> GetListAsync();
        Task<OtherCourse> GetAsync(Guid id);
        Task<Guid> AddAsync(OtherCourse course);
    }
}
