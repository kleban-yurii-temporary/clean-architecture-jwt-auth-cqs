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

        public CourseRepository() {
        
            _courses.Add(new Course { Id= Guid.NewGuid(),
            Desription = "Lorem ipsum description",
            EduYear = "2022/2023",
            Name = "Основи програмування"});
        }

        public async Task<Guid> AddAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetListAsync()
        {
            return _courses;
        }
    }
}
