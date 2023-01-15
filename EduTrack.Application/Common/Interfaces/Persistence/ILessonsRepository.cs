using EduTrack.Domain.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface ILessonsRepository : ICourseOwner<Guid>
    {
        Task<bool> CreateAsync(Guid courseId, int count, LessonType type);
        Task<bool> DeleteAsync(Guid id, bool isGroup);
        Task<IEnumerable<Lesson>> GetAsync(Guid courseId, LessonType type);
        Task<bool> UpdateAsync(Lesson lesson, bool isGroup);
    }
}
