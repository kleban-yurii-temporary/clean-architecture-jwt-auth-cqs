using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface ISubGroupsRepository : ICourseOwner<Guid>
    {
        Task<SubGroup> CreateAsync(Guid courseId);
        Task<IEnumerable<SubGroup>> GetListAsync(Guid courseId);
        Task<SubGroup> UpdateAsync(SubGroup group);
        Task<bool> DeleteAsync(Guid id);
        Task<SubGroup> GetAsync(Guid id);
    }
}
