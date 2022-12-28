using EduTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) {}

        public DbSet<User> Users => Set<User>();
        public DbSet<Speciality> Specialities => Set<Speciality>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<WorkType> WorkTypes => Set<WorkType>();
    }
}
