using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using EduTrack.Infrastracture.Authentication;
using EduTrack.Infrastracture.Context;
using EduTrack.Infrastracture.Persistence;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace EduTrack.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnection");

            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(connectionString)
            );

            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenService, JwtTokenService>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    RoleClaimType = ClaimTypes.Role,
                    ClockSkew = TimeSpan.Zero
                }); ;

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkTypesRepository, WorkTypesRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IOtherCourseRepository, OtherCourseRepository>();
            services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();
            services.AddScoped<IOptionsRepository, OptionsRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<ILessonsRepository, LessonRepository>();
            services.AddScoped<ISubGroupsRepository, SubGroupRepository>();
            services.AddScoped<IStudentRecordsRepository, StudentRecordsRepository>();
            services.AddScoped<IEduYearsRepository, EduYearsRepository>();

            return services;
        }
    }
}