using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using EduTrack.Infrastracture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Persistence
{
    public class OptionsRepository : BaseContextRepository, IOptionsRepository
    {
        public OptionsRepository(DataContext dbCtx)
            : base(dbCtx) { }

        public async Task<Option> AddAsync(Option option, Guid? userId = null)
        {
            option.Key = option.Key.Trim().ToLower();

            if (userId is not null)
                option.Owner = await _dbCtx.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var newOption = await _dbCtx.Options.AddAsync(option);
            await SaveAsync();

            return newOption.Entity;
        }
             
        public async Task DeleteAsync(string key, Guid? userId = null)
        {            
            var option = await GetByKeyAsync(key, userId);

            if (option is not null)
            {
                _dbCtx.Options.Remove(option);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<Option>> GetAllAsync(Guid userId, bool ownOnly = true)
        {
            var options = await _dbCtx.Options.Where(x => x.Owner.Id == userId).ToListAsync();

            if (!ownOnly)
                options.AddRange(await _dbCtx.Options.Where(x => x.Owner == null).ToListAsync());

            return options;
        }

        public async Task<Option> GetByKeyAsync(string key, Guid? userId = null)
        {
            key = key.Trim().ToLower();

            Option option = null;

            if (userId is null)
                option = await _dbCtx.Options.FirstOrDefaultAsync(x => x.Key == key);
            else
                option = await _dbCtx.Options.FirstOrDefaultAsync(x => x.Key == key && x.Owner.Id == userId);

            return option;
        }

        public async Task<Option> UpdateAsync(Option option, Guid? userId = null)
        {
            Option updOption = await GetByKeyAsync(option.Key, userId);

            if (updOption is null) return null;

            if (option.Value != updOption.Value)
                option.Value = updOption.Value;

            if (option.Group != updOption.Group)
                option.Group = updOption.Group;

            await SaveAsync();

            return updOption;
        }


    }
}
