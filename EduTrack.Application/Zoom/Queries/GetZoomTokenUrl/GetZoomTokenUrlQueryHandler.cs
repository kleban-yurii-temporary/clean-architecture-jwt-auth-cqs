using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain.AppErrors;
using EduTrack.Application.WorkTypes.Queries;
using EduTrack.Application.Zoom.Queries.GetAuthUrl;
using EduTrack.Application.Options.Keys.Zoom;

namespace EduTrack.Application.Users.Queries.GetUser
{
    public class GetZoomTokenUrlQueryHandler : IRequestHandler<GetZoomTokenUrlQuery, ErrorOr<string>>
    {
        private readonly IOptionsRepository optionsRepository;

        public GetZoomTokenUrlQueryHandler(IOptionsRepository optionsRepository)
        {
            this.optionsRepository= optionsRepository;
        }

        public async Task<ErrorOr<string>> Handle(GetZoomTokenUrlQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            string token_url = string.Empty, code = string.Empty, client_url = string.Empty;

            var option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.Token.AccessTokenUrl);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.Token.AccessTokenUrl);
            } 
            else 
            {
                token_url = option.Value;

                if(string.IsNullOrEmpty(token_url))
                    return Errors.Options.EmptyValue(ZoomApiKeys.Token.AccessTokenUrl);
            }

            option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.Authorize.AuthorizationCode, request.UserId);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.Authorize.AuthorizationCode);
            }
            else
            {
                code = option.Value;

                if (string.IsNullOrEmpty(code))
                    return Errors.Options.EmptyValue(ZoomApiKeys.Authorize.AuthorizationCode);

            }

            option = await optionsRepository.GetByKeyAsync(OptionKeys.Client.Url);

            if (option is null)
            {
                return Errors.Options.NotFound(OptionKeys.Client.Url);
            }
            else
            {
                client_url = option.Value;

                if (string.IsNullOrEmpty(client_url))
                    return Errors.Options.EmptyValue(OptionKeys.Client.Url);
            }

            var redirect_uri = $"{client_url}111";

            return $"{token_url}?grant_type=suthorization_code&code={code}&redirect_uri={redirect_uri}"; 
        }
    }
}
