using EduTrack.Application.Authentication.Common;
using EduTrack.Contracts.Authentication;
using Mapster;

namespace EduTrack.WebUI.Server.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
