using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface IInviteRepository : ICourseOwner<Guid>
    {
        Task<IEnumerable<CourseInvite>> ListAsync(Guid courseId);
        Task<CourseInvite> Create(Guid courseId);
        Task<CourseInvite> Update(CourseInvite invite);
        Task Delete(Guid id);
        Task<CourseInvite> GetAsync(Guid id);
    }
}
