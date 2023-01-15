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
    public class LessonRepository : BaseContextRepository, ILessonsRepository
    {
        public LessonRepository(DataContext ctx)
            : base(ctx) { }

        public async Task<bool> CreateAsync(Guid courseId, int count, LessonType type)
        {
            var lessons = new List<Lesson>();
            var course = await _dbCtx.Courses.Include(x => x.SubGroups).Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == courseId);

            var date = course.MaxDate.Date;

            var existingLessons = course.Lessons.Where(x => x.LessonType == type).ToList();

            for (int i = 0; i < count; i++)
            {
                while (lessons.Any(x => x.DocumentedDate.Date == date.Date && x.Num == 1) 
                    || existingLessons.Any(x => x.DocumentedDate.Date == date.Date && x.Num == 1))
                    date = date.AddDays(-1);

                long sgUniteCode = new Random(i).Next(100000, 1000000);

                if (course.LabsGroupsCount > 1 && type == LessonType.Laboratory || course.PracticeGroupsCount > 1 && type == LessonType.Pactice)
                {
                    int ix = 1;
                    foreach (var sg in course.SubGroups)
                    {
                        lessons.Add(new Lesson
                        {
                            Course = course,
                            Title = "-",
                            SubGroup = await _dbCtx.SubGroups.FindAsync(sg.Id),
                            Num = ix++,
                            WorkType = await _dbCtx.WorkTypes.FirstAsync(x => x.LessonType == type),
                            LessonType = type,
                            GradeType = GradeType.Simple,
                            RealDate = date.Date.Date,
                            DocumentedDate = date.Date.Date,
                            SubGroupUniteCode = sgUniteCode
                        });
                    }
                }
                else
                {
                    lessons.Add(new Lesson
                    {
                        Course = course,
                        Title = "-",
                        Num = 1,
                        WorkType = await _dbCtx.WorkTypes.FirstAsync(x => x.LessonType == type),
                        LessonType = type,
                        GradeType = GradeType.Simple,
                        RealDate = date.Date.Date,
                        DocumentedDate = date.Date.Date
                    });
                }


            }

            await _dbCtx.Lessons.AddRangeAsync(lessons);

            await SaveAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, bool isGroup)
        {
            if (isGroup)
            {
                throw new NotImplementedException("SubGroup Lessons Delete not implemented");
            }
            else
            {
                _dbCtx.Lessons.Remove(_dbCtx.Lessons.Find(id));
            }

            await SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Lesson>> GetAsync(Guid courseId, LessonType type)
        {
            return await _dbCtx.Lessons
                .Include(x => x.SubGroup)
                .Include(x => x.WorkType)
                .Where(x => x.Course.Id == courseId && x.LessonType == type)
                .OrderBy(x=> x.DocumentedDate)
                .ToListAsync();
        }

        public Guid GetOwnerId(Guid objectId)
        {
            return _dbCtx.Lessons.Include(x => x.Course).First(x => x.Id == objectId).Course.OwnerId;
        }

        public async Task<bool> UpdateAsync(Lesson lesson, bool IsGroup)
        {
            if(IsGroup)
            {
                throw new NotImplementedException("SubGroup Lessons Edit not implemented");
            } 
            else
            {
                var ulsn = await _dbCtx.Lessons.Include(x=> x.WorkType).FirstAsync(x=> x.Id == lesson.Id);

                if (ulsn.DocumentedDate != lesson.DocumentedDate.Date) ulsn.DocumentedDate = lesson.DocumentedDate.Date;
                if (ulsn.RealDate != lesson.RealDate.Date) ulsn.RealDate = lesson.RealDate.Date;
                if (ulsn.Num != lesson.Num) ulsn.Num = lesson.Num;
                if (ulsn.Title != lesson.Title) ulsn.Title = lesson.Title;
                if (ulsn.MaxGrade != lesson.MaxGrade) ulsn.MaxGrade = lesson.MaxGrade;

                if ((ulsn.WorkType is null && lesson.WorkType is not null) 
                    || (ulsn.WorkType is not null && lesson.WorkType is not null && ulsn.WorkType.Id != lesson.WorkType.Id))
                    ulsn.WorkType = await _dbCtx.WorkTypes.FindAsync(lesson.WorkType.Id);
            }

            await SaveAsync();

            return true;
        }
    }
}
