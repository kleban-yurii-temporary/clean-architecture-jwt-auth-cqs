using EduTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        {
            //Database.EnsureCreated();
        }

        public DbSet<EduYear> EduYears => Set<EduYear>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseType> CourseTypes => Set<CourseType>();
        public DbSet<WorkType> WorkTypes => Set<WorkType>();
        public DbSet<Option> Options => Set<Option>();
        public DbSet<OtherCourse> OtherCourses=> Set<OtherCourse>();
        public DbSet<StudentRecord> StudentRecords => Set<StudentRecord>();
        public DbSet<CourseInvite> CourseInvites => Set<CourseInvite>();
        public DbSet<SubGroup> SubGroups => Set<SubGroup>();
        public DbSet<GradeAndPresense> GradesAndPresenses=> Set<GradeAndPresense>();
        public DbSet<ComplexGradeItem> ComplexGradeItems=> Set<ComplexGradeItem>();
        public DbSet<ComplexGradeItemHeader> ComplexGradeItemHeaders => Set<ComplexGradeItemHeader>();
        public DbSet<Lesson> Lessons => Set<Lesson>();
        public DbSet<LessonTime> LessonTimes => Set<LessonTime>();
        public DbSet<OtherWorkHours> OtherWorkHours => Set<OtherWorkHours>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var userId = modelBuilder.SeedUser();
            modelBuilder.SeedEduYears();
            modelBuilder.SeedWorkTypes(); 
            modelBuilder.SeedLessonTimes();
            modelBuilder.SeedOptions(userId);
        }
    }
}
