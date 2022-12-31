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
    public class GetZoomAuthUrlQueryHandler : IRequestHandler<GetZoomAuthUrlQuery, ErrorOr<string>>
    {
        private readonly IOptionsRepository optionsRepository;

        public GetZoomAuthUrlQueryHandler(IOptionsRepository optionsRepository)
        {
            this.optionsRepository= optionsRepository;
        }

        public async Task<ErrorOr<string>> Handle(GetZoomAuthUrlQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            string auth_url = string.Empty, client_id = string.Empty, client_url;

            var option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.Authorize.Url);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.Authorize.Url);
            } 
            else 
            {
                auth_url = option.Value;

                if(string.IsNullOrEmpty(auth_url))
                    return Errors.Options.EmptyValue(ZoomApiKeys.Authorize.Url);
            }

            option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.General.ClientId, request.UserId);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.General.ClientId);
            }
            else
            {
                client_id = option.Value;

                if (string.IsNullOrEmpty(client_id))
                    return Errors.Options.EmptyValue(ZoomApiKeys.General.ClientId);
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

            var redirect_uri = $"{client_url}api/zoom/oauthredirect";
            return $"{auth_url}?response_type=code&client_id={client_id}&redirect_uri={redirect_uri}"; 
        }
    }
}
