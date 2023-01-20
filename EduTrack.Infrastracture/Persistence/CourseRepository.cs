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
    public class CourseRepository : BaseContextRepository, ICourseRepository
    {
        public CourseRepository(DataContext ctx)
            : base(ctx) { }

        public async Task<Guid> AddAsync(Course course)
        {
            course.MaxDate = DateTime.UtcNow.Month > 6
                ? new DateTime(DateTime.UtcNow.Year, 12, 25).Date
                : new DateTime(DateTime.UtcNow.Year + 1, 6, 25).Date;

            course.EduYear = _dbCtx.EduYears.Last();

            var itm = await _dbCtx.Courses.AddAsync(course);
            await SaveAsync();
            return itm.Entity.Id;
        }

        public async Task<Course> GetAsync(Guid id)
        {
            return await _dbCtx.Courses
                .Include(x=> x.EduYear)
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetListAsync()
        {
            return await _dbCtx.Courses.Include(x=> x.EduYear).ToListAsync();
        }

        public Guid GetOwnerId(Guid objectId)
        {
            return _dbCtx.Courses.First(x => x.Id == objectId).OwnerId;
        }

        public async Task<Course> GetWithStudentsAndGroupsDetailsAsync(Guid id)
        {
            return await _dbCtx.Courses
                .Include(x => x.Students).ThenInclude(x => x.User)
                .Include(x => x.Students).ThenInclude(x => x.SubGroup)
                .Include(x => x.SubGroups)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            var updCourse = await _dbCtx.Courses.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == course.Id);

            if (updCourse.Title != course.Title) updCourse.Title = course.Title;
            if (updCourse.ShortTitle != course.ShortTitle) updCourse.ShortTitle = course.ShortTitle;

            if (updCourse.LecturesHours != course.LecturesHours) updCourse.LecturesHours = course.LecturesHours;
            if (updCourse.PracticeHours != course.PracticeHours) updCourse.PracticeHours = course.PracticeHours;
            if (updCourse.PracticeGroupsCount != course.PracticeGroupsCount) updCourse.PracticeGroupsCount = course.PracticeGroupsCount;
            if (updCourse.LaboratoryHours != course.LaboratoryHours) updCourse.LaboratoryHours = course.LaboratoryHours;
            if (updCourse.LabsGroupsCount != course.LabsGroupsCount) updCourse.LabsGroupsCount = course.LabsGroupsCount;
            if (updCourse.ConsultationHours != course.ConsultationHours) updCourse.ConsultationHours = course.ConsultationHours;
            if (updCourse.ExamHours != course.ExamHours) updCourse.ExamHours = course.ExamHours;

            if (updCourse.StudentsCount != course.StudentsCount) updCourse.StudentsCount = course.StudentsCount;

            if (updCourse.CourseTypeId != course.CourseTypeId) updCourse.CourseTypeId = course.CourseTypeId;
            if (updCourse.GroupCode != course.GroupCode) updCourse.GroupCode = course.GroupCode;
            if (updCourse.EduYear.Id != course.EduYear.Id) updCourse.EduYear = course.EduYear;
            if (updCourse.Semestr != course.Semestr) updCourse.Semestr = course.Semestr;
            if (updCourse.MaxDate.Date != course.MaxDate.Date) updCourse.MaxDate = course.MaxDate.Date;
            if (updCourse.IsActive != course.IsActive) updCourse.IsActive = course.IsActive;

            await SaveAsync();

            return true;
        }
    }
}
