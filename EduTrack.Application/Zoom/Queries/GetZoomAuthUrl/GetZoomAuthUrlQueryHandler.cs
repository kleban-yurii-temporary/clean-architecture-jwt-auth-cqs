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

            string auth_url = string.Empty, client_id = string.Empty, client_url, redirect_url;

            var option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.Authorize.AuthUrl);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.Authorize.AuthUrl);
            } 
            else 
            {
                auth_url = option.Value;

                if(string.IsNullOrEmpty(auth_url))
                    return Errors.Options.EmptyValue(ZoomApiKeys.Authorize.AuthUrl);
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

            option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.Authorize.RedirectUrl);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.Authorize.RedirectUrl);
            }
            else
            {
                redirect_url = option.Value;

                if (string.IsNullOrEmpty(redirect_url))
                    return Errors.Options.EmptyValue(OptionKeys.Client.ClientUrl);
            }

            return $"{auth_url}?response_type=code&client_id={client_id}&redirect_uri={redirect_url}"; 
        }
    }
}
