using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface IStudentRecordsRepository : ICourseOwner<Guid>
    {
        Task<IEnumerable<StudentRecord>> ListAsync(Guid courseId);
        Task<IEnumerable<StudentRecord>> NoUsersListAsync(Guid courseId);
        Task<StudentRecord> CreateAsync(StudentRecord record, Guid courseId);
        Task<StudentRecord> UpdateAsync(StudentRecord record);
        Task DeleteAsync(Guid id);
        Task<StudentRecord> GetAsync(Guid id);
        Task<StudentRecord> GetByEmailAndCourseAsync(string email, Guid courseId);
    }
}
