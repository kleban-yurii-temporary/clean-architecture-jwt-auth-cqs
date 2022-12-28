using EduTrack.Application;
using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using EduTrack.Infrastracture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Persistence
{
    public class UserRepository : IUserRepository
    {
        private DataContext _ctx;

        public UserRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Guid> AddAsync(User user)
        {
            var newUser = await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return newUser.Entity.Id;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            email = StringHelper.ApplyTL(email);
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User>? GetUserAsync(Guid id)
        {
            return await _ctx.Users.FirstAsync(x=> x.Id == id);
        }

        public async Task<bool> AddUserToRoleAsync(Guid id, string role)
        {
            role = StringHelper.ApplyTL(role);

            var user = await _ctx.Users.FirstAsync(x => x.Id == id);
            user.Role = role;
            await _ctx.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserApproveStatusAsync(Guid id, bool status)
        {
            var user = await _ctx.Users.FirstAsync(x => x.Id == id);
            user.IsApproved = status;
            await _ctx.SaveChangesAsync();
            return user.IsApproved;
        }

        public async Task UpdateAsync(User user)
        {           
            var dbUser = await _ctx.Users.FirstAsync(x => x.Id == user.Id);

            if (dbUser.RefreshToken != user.RefreshToken)
            {
                dbUser.RefreshToken = user.RefreshToken;
                dbUser.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            }

            await _ctx.SaveChangesAsync();
        }
    }
}
