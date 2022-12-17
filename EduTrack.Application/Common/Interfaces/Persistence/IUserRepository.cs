using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User>? GetUserByEmailAsync(string email);
        Task<User>? GetUserAsync(Guid id);
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> AddUserToRoleAsync(Guid id, string role);
        Task<bool> UpdateUserApproveStatusAsync(Guid id, bool status);
        Task UpdateAsync(User user);
    }
}
