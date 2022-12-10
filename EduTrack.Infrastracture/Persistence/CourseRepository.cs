using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Persistence
{
    public class CourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new();

        public CourseRepository()
        {
            _courses.AddRange(
                new List<Course> {
                    new Course {
                        Id = Guid.NewGuid(),
                        Desription = "Lorem ipsum description",
                        EduYear = "2022/2023",
                        Title = "Основи програмування",
                        IsActive = true
                    },
                    new Course {
                        Id = Guid.NewGuid(),
                        Desription = "Lorem ipsum description",
                        EduYear = "2022/2023",
                        Title = "Modern database systems: SQL + NoSQL"
                    }
                });
        }

        public async Task<Guid> AddAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetListAsync()
        {
            return _courses;
        }
    }
}
