using EduTrack.Application.Authentication.Commands.Register;
using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Options.Keys.Zoom;
using EduTrack.Application.Users.Commands.ChangeRole;
using EduTrack.Contracts.Authentication;
using EduTrack.Domain.Entities;
using EduTrack.Infrastracture.Context;
using EduTrack.WebUI.Shared.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.WebUI.Server.Controllers
{
    [Route("init")]
    [ApiController]
    public class DbController : ApiController
    {
        private readonly DataContext _ctx;

        public DbController(
            IMediator mediator,
            IMapper mapper,
            DataContext ctx)
            : base(mediator, mapper)
        {
            _ctx = ctx;
        }

        [HttpPost("/api/db/init")]
        public async Task<IActionResult> InitDatabaseAsync()
        {
            await Task.CompletedTask;

            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var teacherId = _ctx.Users.First().Id;

            await initCourses(teacherId);
            await initOtherCourses(teacherId);

            var opts = await _ctx.Options.ToListAsync();

            await Task.CompletedTask;

            return Ok("Базу ініціалізовано");
        }

        private async Task initOtherCourses(Guid teacherId)
        {
            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                EduYear = "2022/2023",
                GroupCode = "Ек-3",
                Hours = 21,
                IsActive= true,
                OwnerId= teacherId,
                Title  ="Курсова робота",
                Semestr = 2,
                StudentsCount = 7,
                WorkType = await _ctx.WorkTypes.FirstAsync(x=> x.Order == 9)                
            });

            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                EduYear = "2022/2023",
                GroupCode = "Ек-4",
                Hours = 6,
                IsActive = true,
                OwnerId = teacherId,
                Title = "Курсова робота",
                Semestr = 2,
                StudentsCount = 2,
                WorkType = await _ctx.WorkTypes.FirstAsync(x => x.Order == 9)
            });

            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                EduYear = "2022/2023",
                GroupCode = "Кн-2",
                Hours = 16,
                IsActive = true,
                OwnerId = teacherId,
                Title = "Навчальна практика з дисципліни \"Програмування С#\"",
                Semestr = 2,
                StudentsCount = 8,
                WorkType = await _ctx.WorkTypes.FirstAsync(x => x.Order == 14)
            });

            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                EduYear = "2022/2023",
                GroupCode = "Кн-4",
                Hours = 75,
                IsActive = true,
                OwnerId = teacherId,
                Title = "Кваліфікаційна робота/проєкт",
                Semestr = 2,
                StudentsCount =5,
                WorkType = await _ctx.WorkTypes.FirstAsync(x => x.Order == 10)
            });

            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                EduYear = "2022/2023",
                GroupCode = "Кн-4",
                Hours = 7.5,
                IsActive = true,
                OwnerId = teacherId,
                Title = "Захист кваліфікаційних робіт",
                Semestr = 2,
                StudentsCount = 15,
                WorkType = await _ctx.WorkTypes.FirstAsync(x => x.Order == 13)
            });

            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                EduYear = "2022/2023",
                Hours = 17,
                IsActive = true,
                OwnerId = teacherId,
                Title = "Консультації впродовж семестру",
                Semestr = 2
            });

            await _ctx.SaveChangesAsync();
        }

  
        #region Courses

        private async Task initCourses(Guid teacherId)
        {
            await Task.CompletedTask;

            var vybirk = await _ctx.CourseTypes.AddAsync(new CourseType { Title = "Вибірковий" });
            var obovyaz = await _ctx.CourseTypes.AddAsync(new CourseType { Title = "Обов'язковий" });
            await _ctx.SaveChangesAsync();

            var rCourseEc = await _ctx.Courses.AddAsync(new Course
            {
                Title = "Вступ до прикладного програмування в R",
                StudentsCount = 13,
                Type = obovyaz.Entity,
                LecturesHours = 10,
                LaboratoryHours= 26,
                GroupCode = "Ек-1",
                LabsGroupsCount = 1,
                EduYear = "2022/2023",
                Semestr = 2,
                IsActive = false,
                OwnerId = teacherId
            });

            var rCourseFc = await _ctx.Courses.AddAsync(new Course
            {
                Title = "Вступ до прикладного програмування в R",
                StudentsCount = 15,
                LecturesHours = 0,
                Type = obovyaz.Entity,
                LaboratoryHours = 26,
                EduYear = "2022/2023",
                Semestr = 2,
                GroupCode = "Фк-1",
                IsActive = false, 
                OwnerId = teacherId
            });

            var opCourseEc = await _ctx.Courses.AddAsync(new Course
            {
                Title = "Основи програмування",
                StudentsCount = 21,
                LecturesHours = 10,
                Type = vybirk.Entity,
                PracticeHours = 54,
                EduYear = "2022/2023",
                Semestr = 2,
                GroupCode = "Ек-1",
                IsActive = false,
                OwnerId = teacherId
            });

            var daCourseEc = await _ctx.Courses.AddAsync(new Course
            {
                Title = "Аналіз даних",
                StudentsCount = 25,
                LecturesHours = 30,
                Type = vybirk.Entity,
                PracticeHours = 14,
                LaboratoryHours = 28,
                LabsGroupsCount= 2,
                EduYear = "2022/2023",
                ConsultationHours=2,
                ExamHours = 8.25,
                Semestr = 2,
                GroupCode = "Ек-2",
                IsActive = false,
                OwnerId = teacherId
            });

            await _ctx.OtherCourses.AddAsync(new OtherCourse
            {
                Title = "Курсова робота",
                EduYear = "2022/2023",
                Semestr = 2,
                GroupCode = "ЕК-3",
                StudentsCount= 7,
                Hours = 21,
                IsActive= false,
                OwnerId = teacherId                
            });

            await _ctx.SaveChangesAsync();


        }

        #endregion

      
    }
}
