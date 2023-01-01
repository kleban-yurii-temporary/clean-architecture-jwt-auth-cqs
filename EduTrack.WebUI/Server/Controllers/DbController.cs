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

            var teacherId = await initUsersAsync();
            await initWorkTypes();
            await initOptions();
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

        #region Options

        private async Task initOptions()
        {
            await _ctx.Options.AddRangeAsync(
                new List<Option>
                {
                    new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.General.BaseUrl,
                        Value = "https://api.zoom.us/v2",
                        CantBeRemoved = true
                    },
                    new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Me,
                        Value = "https://api.zoom.us/v2/users/me",
                        CantBeRemoved = true
                    },
                    new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Meetings,
                        Value = "https://api.zoom.us/v2/users/me/meetings?type=previous_meetings",
                        CantBeRemoved = true
                    },
                    new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Recordings,
                        Value = "https://api.zoom.us/v2/users/me/recordings",
                        CantBeRemoved = true
                    },
                    new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Webinars,
                        Value = "https://api.zoom.us/v2/users/me/webinars",
                        CantBeRemoved = true
                    },
                    new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.General.ClientId, 
                        Value = "Yo_UM8esSOqJCHMRHCJVg", 
                        CantBeRemoved = true, 
                        Owner = await _ctx.Users.FirstAsync(x=> x.Email == "yurakleban@gmail.com")
                    },
                    new Option {
                        Group = ZoomApiKeys.Group, 
                        Key = ZoomApiKeys.General.ClientSecret, 
                        Value = "PsF2x0mNgKwe77LhROffARNyI6rDCZeO", 
                        CantBeRemoved = true,
                        Owner = await _ctx.Users.FirstAsync(x=> x.Email == "yurakleban@gmail.com")
                    },
                    new Option {
                        Group = ZoomApiKeys.Group, 
                        Key = ZoomApiKeys.Authorize.AuthUrl, 
                        Value = "https://zoom.us/oauth/authorize", 
                        CantBeRemoved = true
                    },
                new Option {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Token.AccessTokenUrl,
                        Value = "https://zoom.us/oauth/token",
                        CantBeRemoved = true
                    }});

            await _ctx.SaveChangesAsync();
        }

        #endregion

        #region WorkTypes 

        private async Task initWorkTypes()
        {
            await Task.CompletedTask;

            var wts = new string[]
            {
                "Лекційні заняття",
                "Групові заняття",
                "Лабораторні заняття",
                "Консультації до екзамену",
                "Консультації впродовж семестру",
                "Проміжний контроль",
                "Залік",
                "Екзамен",
                "Курсові роботи",
                "Керівництво кваліфікаційними роботами",
                "Рецензування",
                "Участь у роботі ЕК(захист)",
                "Участь у роботі ЕК(екзамен)",
                "Керівництво практикою",
                "Керівництво аспірантами",
                "Керівництво стажистами",
                "Контрольні відвідування"
            };

            var wts_s = new string[]
            {
                "Лекц.",
                "Груп.",
                "Лаб.",
                "Конс. екз.",
                "Конс. сем",
                "Пром. контр.",
                "Залік",
                "Екзамен",
                "Курс. роб.",
                "Кваліф. роб.",
                "Реценз.",
                "ЕК(захист)",
                "ЕК(екзамен)",
                "Кер. практ.",
                "Кер. асп.",
                "Кер. стаж.",
                "Контр. відв."
            };

            for (int i = 1; i <= wts.Length; i++)
            {
                var wt = new WorkType
                {
                    Order = i,
                    Title = wts[i - 1],
                    ShortTitle = wts_s[i - 1]                    
                };

                if (wt.Order == 6 || wt.Order == 7) wt.PerStudentNorm = 0.25;
                if (wt.Order == 8) wt.PerStudentNorm = 0.33;
                if (wt.Order == 9) wt.PerStudentNorm = 3;
                if (wt.Order == 10) wt.PerStudentNorm = 15;
                if (wt.Order == 13) wt.PerStudentNorm = 0.5;
                if (wt.Order == 14) wt.PerStudentNorm = 2;
                await _ctx.WorkTypes.AddAsync(wt);
            }

            await _ctx.SaveChangesAsync();
        }

        #endregion
  
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
                GroupsCount = 1,
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
                GroupsCount = 1,
                EduYear = "2022/2023",
                Semestr = 2,
                GroupCode = "Фк-1",
                IsActive = false, 
                OwnerId = teacherId
            });

            await _ctx.SaveChangesAsync();


        }

        #endregion

        #region Users

        private async Task<Guid> initUsersAsync()
        {
            await Task.CompletedTask;

            var command1 = _mapper.Map<RegisterCommand>(
                new UserRegisterDto("yurakleban@gmail.com", "demoPA$$W0RD", "Юрій", "Клебан"));

            var result = await _mediator.Send(command1);

            await _mediator.Send(new UpdateRoleCommand(result.Value, "teacher"));
            await _mediator.Send(new UpdateApproveStatusCommand(result.Value, true));

            return result.Value;
        }

        #endregion        
    }
}
