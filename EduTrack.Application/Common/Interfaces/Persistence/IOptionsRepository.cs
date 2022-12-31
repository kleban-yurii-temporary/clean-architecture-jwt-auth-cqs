using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface IOptionsRepository
    {
        Task<Option> GetByKeyAsync(string key, Guid? userId = null);
        Task<IEnumerable<Option>> GetAllAsync(Guid userId, bool ownOnly = true);      
        Task<Option> AddAsync(Option option, Guid? userId = null);
        Task<Option> UpdateAsync(Option option, Guid? userId = null);
        Task DeleteAsync(string key, Guid? userId = null);
    }
}
