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

            await initUsersAsync();
            await initSpecialities();
            await initWorkTypes();
            await initOptions();

            var opts = await _ctx.Options.ToListAsync();

            await Task.CompletedTask;

            return Ok("Базу ініціалізовано");
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
                        Key = ZoomApiKeys.Authorize.Url, 
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
                await _ctx.WorkTypes.AddAsync(new WorkType
                {
                    Order = i,
                    Title = wts[i - 1],
                    ShortTitle = wts_s[i - 1]
                });
            }

            await _ctx.SaveChangesAsync();
        }

        #endregion

        #region Specialities

        private Guid ekSpecId;
        private Guid knSpecId;

        private async Task initSpecialities()
        {
            await Task.CompletedTask;

            var ek = await _ctx.Specialities
                .AddAsync(new Speciality { Title = "Спеціальність 051 Економіка (економічна кібернетика)" });

            var kn = await _ctx.Specialities
                .AddAsync(new Speciality { Title = "Спеціальність 122 Комп'ютерні науки" });

            await _ctx.SaveChangesAsync();

            ekSpecId = ek.Entity.Id;
            knSpecId = kn.Entity.Id;
        }

        #endregion

        #region Courses

        private async Task initCourses()
        {
            await Task.CompletedTask;

            /*await _ctx.Specialities.AddRangeAsync(new[]
            {
                new Speciality {Title = "Спеціальність 051 Економіка (економічна кібернетика)"},
                new Speciality {Title = "Спеціальність 122 Комп'ютерні науки"}
            });*/

            await _ctx.SaveChangesAsync();
        }

        #endregion

        #region Users

        private async Task initUsersAsync()
        {
            await Task.CompletedTask;

            var command1 = _mapper.Map<RegisterCommand>(
                new UserRegisterDto("yurakleban@gmail.com", "demoPA$$W0RD", "Юрій", "Клебан"));

            var result = await _mediator.Send(command1);

            await _mediator.Send(new UpdateRoleCommand(result.Value, "teacher"));
            await _mediator.Send(new UpdateApproveStatusCommand(result.Value, true));
        }

        #endregion        
    }
}
