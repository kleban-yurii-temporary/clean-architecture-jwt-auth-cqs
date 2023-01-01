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
            : base(options) {}

        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseType> CourseTypes => Set<CourseType>();
        public DbSet<WorkType> WorkTypes => Set<WorkType>();
        public DbSet<Option> Options => Set<Option>();
        public DbSet<OtherCourse> OtherCourses=> Set<OtherCourse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.OwnedCourses).WithOne(x => x.Owner);
        }
    }
}
