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
    public class StudentRecordsRepository : BaseContextRepository, IStudentRecordsRepository
    {
        public StudentRecordsRepository(DataContext ctx)
            : base(ctx) { }

        public async Task<StudentRecord> CreateAsync(StudentRecord record, Guid courseId)
        {
            record.Course = await _dbCtx.Courses.FindAsync(courseId);
            var std = await _dbCtx.StudentRecords.AddAsync(record);
            await SaveAsync();
            return std.Entity;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentRecord> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentRecord> GetByEmailAndCourseAsync(string email, Guid courseId)
        {
            return await _dbCtx.StudentRecords.FirstOrDefaultAsync(x=> x.Email == email && x.Course.Id == courseId);
        }

        public Guid GetOwnerId(Guid objectId)
        {
            return _dbCtx.StudentRecords.Include(x => x.Course).First(x => x.Id == objectId).Course.OwnerId;
        }

        public async Task<IEnumerable<StudentRecord>> ListAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentRecord>> NoUsersListAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentRecord> UpdateAsync(StudentRecord record)
        {
            var updRecord = await _dbCtx.StudentRecords.Include(x=> x.SubGroup).FirstOrDefaultAsync(x=> x.Id == record.Id);

            if (updRecord == null)
                throw new NotImplementedException("Student not found for update");

            if (updRecord.FirstName != record.FirstName)
                updRecord.FirstName = record.FirstName;

            if (updRecord.LastName != record.LastName)
                updRecord.LastName = record.LastName;

            if (updRecord.Email != record.Email)
                updRecord.Email = record.Email;

            if(record.SubGroup.Id != Guid.Empty)
            {
                if (updRecord.SubGroup == null || (updRecord.SubGroup != null && updRecord.SubGroup.Id != record.SubGroup.Id))
                    updRecord.SubGroup = await _dbCtx.SubGroups.FindAsync(record.SubGroup.Id);
            } 
            else
            {
                if(updRecord.SubGroup != null) 
                    _dbCtx.SubGroups.Find(updRecord.SubGroup.Id).Students.Remove(updRecord);
            }

            await SaveAsync();

            return updRecord;
        }
    }
}
