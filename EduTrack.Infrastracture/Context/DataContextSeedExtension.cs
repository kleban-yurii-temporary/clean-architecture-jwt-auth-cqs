using EduTrack.Application.Options.Keys.Zoom;
using EduTrack.Domain.Entities;
using EduTrack.Helpers.Password;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EduTrack.Infrastracture.Context
{
    public static class DataContextSeedExtension
    {
        public static Guid SeedUser(this ModelBuilder builder)
        {
            var userId = Guid.NewGuid();

            var (hash, salt) = PasswordService.CreatePasswordHash("demoPA$$W0RD");

            var user = new User
            {
                Id = userId,
                Email = "yurakleban@gmail.com",
                FirstName = "Юрій",
                LastName = "Клебан",
                IsApproved = true,
                Role = "teacher",
                PasswordHash = hash,
                PasswordSalt = salt
            };

            builder.Entity<User>().HasData(user);

            return userId;
        }
        public static void SeedWorkTypes(this ModelBuilder builder)
        {
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

            var list = new List<WorkType>();

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

                if (wt.Order == 1) wt.LessonType = LessonType.Lecture;
                if (wt.Order == 2) wt.LessonType = LessonType.Pactice;
                if (wt.Order == 3) wt.LessonType = LessonType.Laboratory;
                if (wt.Order == 4) wt.LessonType = LessonType.Consultation;
                if (wt.Order == 8) wt.LessonType = LessonType.Exam;

                list.Add(wt);
            }

            builder.Entity<WorkType>().HasData(list);
        }
        public static void SeedLessonTimes(this ModelBuilder builder)
        {
            builder.Entity<LessonTime>().HasData(
                new LessonTime { Num = 0, Start = new DateTime(1, 1, 1, 8, 0, 0), End = new DateTime(1, 1, 1, 8, 50, 0) },
                new LessonTime { Num = 1, Start = new DateTime(1, 1, 1, 8, 0, 0), End = new DateTime(1, 1, 1, 8, 50, 0) },
                new LessonTime { Num = 2, Start = new DateTime(1, 1, 1, 9, 0, 0), End = new DateTime(1, 1, 1, 10, 20, 0) },
                new LessonTime { Num = 3, Start = new DateTime(1, 1, 1, 10, 40, 0), End = new DateTime(1, 1, 1, 12, 0, 0) },
                new LessonTime { Num = 4, Start = new DateTime(1, 1, 1, 12, 30, 0), End = new DateTime(1, 1, 1, 13, 50, 0) },
                new LessonTime { Num = 5, Start = new DateTime(1, 1, 1, 14, 10, 0), End = new DateTime(1, 1, 1, 15, 30, 0) },
                new LessonTime { Num = 6, Start = new DateTime(1, 1, 1, 15, 40, 0), End = new DateTime(1, 1, 1, 17, 00, 0) },
                new LessonTime { Num = 7, Start = new DateTime(1, 1, 1, 17, 10, 0), End = new DateTime(1, 1, 1, 18, 30, 0) },
                new LessonTime { Num = 8, Start = new DateTime(1, 1, 1, 18, 40, 0), End = new DateTime(1, 1, 1, 20, 0, 0) });
        }
        public static void SeedOptions(this ModelBuilder builder, Guid UserId)
        {
            builder.Entity<Option>().HasData(
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.General.BaseUrl,
                        Value = "https://api.zoom.us/v2",
                        CantBeRemoved = true
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Me,
                        Value = "https://api.zoom.us/v2/users/me",
                        CantBeRemoved = true
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Meetings,
                        Value = "https://api.zoom.us/v2/users/me/meetings?type=previous_meetings",
                        CantBeRemoved = true
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Recordings,
                        Value = "https://api.zoom.us/v2/users/me/recordings",
                        CantBeRemoved = true
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Users.Webinars,
                        Value = "https://api.zoom.us/v2/users/me/webinars",
                        CantBeRemoved = true
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.General.ClientId,
                        Value = "Yo_UM8esSOqJCHMRHCJVg",
                        CantBeRemoved = true,
                        OwnerId = UserId
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.General.ClientSecret,
                        Value = "PsF2x0mNgKwe77LhROffARNyI6rDCZeO",
                        CantBeRemoved = true,
                        OwnerId = UserId
                    },
                    new Option
                    {
                        Group = ZoomApiKeys.Group,
                        Key = ZoomApiKeys.Authorize.AuthUrl,
                        Value = "https://zoom.us/oauth/authorize",
                        CantBeRemoved = true
                    },
                    new Option
                {
                    Group = ZoomApiKeys.Group,
                    Key = ZoomApiKeys.Token.AccessTokenUrl,
                    Value = "https://zoom.us/oauth/token",
                    CantBeRemoved = true
                });
        }
    }
}
