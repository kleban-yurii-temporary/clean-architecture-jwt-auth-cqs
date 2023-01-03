using EduTrack.Contracts.Authentication;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Dtos.Courses;
using Mapster;

namespace EduTrack.WebUI.Server.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CourseType, CourseTypeDto>();

            /*config.NewConfig<AuthenticationResult, AuthenticationResponseDto>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);*/
        }
    }
}
