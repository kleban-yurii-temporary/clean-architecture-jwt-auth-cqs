﻿using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetListAsync();
        Task<Guid> AddAsync(Course course);
    }
}
