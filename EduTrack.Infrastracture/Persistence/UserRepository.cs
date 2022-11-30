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
    }
}
