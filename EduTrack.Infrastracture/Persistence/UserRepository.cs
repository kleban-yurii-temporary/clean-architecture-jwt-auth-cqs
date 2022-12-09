using EduTrack.Application;
using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public async Task AddAsync(User user)
        {
            _users.Add(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            email = StringHelper.ApplyTL(email);
            return _users.FirstOrDefault(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return _users;
        }

        public async Task<User>? GetUserAsync(Guid id)
        {
            return _users.First(x=> x.Id == id);
        }

        public async Task<bool> AddUserToRoleAsync(Guid id, string role)
        {
            role = StringHelper.ApplyTL(role);

            var user = _users.First(x => x.Id == id);
            user.Role = role;

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserApproveStatusAsync(Guid id, bool status)
        {
            var user = _users.First(x => x.Id == id);
            user.IsApproved = status;
            return user.IsApproved;
        }
    }
}
