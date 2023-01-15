using EduTrack.Domain.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface ICourseRepository: ICourseOwner<Guid>
    {
        Task<IEnumerable<Course>> GetListAsync();
        Task<Course> GetAsync(Guid id);
        Task<Guid> AddAsync(Course course);
        Task<Course> GetWithStudentsAndGroupsDetailsAsync(Guid id);
        Task<bool> UpdateAsync(Course course);
    }
}
