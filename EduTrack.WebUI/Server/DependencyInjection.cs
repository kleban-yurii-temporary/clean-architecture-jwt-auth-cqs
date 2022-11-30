using EduTrack.WebUI.Server.Common.Mapping;
using EduTrack.WebUI.Server.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

namespace EduTrack.WebUI.Server
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddProblemDetails(o => o.CustomizeProblemDetails = ctx =>
            {
                var problemCorrelationId = Guid.NewGuid().ToString();
                ctx.ProblemDetails.Instance = problemCorrelationId;
            });

            services.AddSingleton<ProblemDetailsFactory, EduTrackProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }
    }
}
