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

            string token_url, redirect_url;
            
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
                       
            option = await optionsRepository.GetByKeyAsync(ZoomApiKeys.Authorize.RedirectUrl);

            if (option is null)
            {
                return Errors.Options.NotFound(ZoomApiKeys.Authorize.RedirectUrl);
            }
            else
            {
                redirect_url = option.Value;

                if (string.IsNullOrEmpty(redirect_url))
                    return Errors.Options.EmptyValue(ZoomApiKeys.Authorize.RedirectUrl);
            }

            return $"{token_url}?grant_type=authorization_code&code={request.AuthCode}&redirect_uri={redirect_url}"; 
        }
    }
}
