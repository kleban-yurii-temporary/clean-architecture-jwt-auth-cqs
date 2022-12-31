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
    public class GetZoomAuthBasicHeaderQueryHandler : IRequestHandler<GetZoomAuthBasicHeaderQuery, ErrorOr<string>>
    {
        private readonly IOptionsRepository optionsRepository;

        public GetZoomAuthBasicHeaderQueryHandler(IOptionsRepository optionsRepository)
        {
            this.optionsRepository= optionsRepository;
        }

        public async Task<ErrorOr<string>> Handle(GetZoomAuthBasicHeaderQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            string client_id = string.Empty, client_secret = string.Empty;

            if (!await optionsRepository.AnyByKeyAsync(ZoomApiKeys.General.ClientId))
            {
                return Errors.Options.NotFound(ZoomApiKeys.General.ClientId);
            } 
            else 
            {
                client_id = (await optionsRepository.GetByKeyAsync(ZoomApiKeys.General.ClientId)).Value;

                if(string.IsNullOrEmpty(client_id))
                    return Errors.Options.EmptyValue(ZoomApiKeys.General.ClientId);
            }

            if (!await optionsRepository.AnyByKeyAsync(ZoomApiKeys.General.ClientSecret))
            {
                return Errors.Options.NotFound(ZoomApiKeys.General.ClientSecret);
            }
            else
            {
                client_secret = (await optionsRepository.GetByKeyAsync(ZoomApiKeys.General.ClientSecret)).Value;

                if (string.IsNullOrEmpty(client_secret))
                    return Errors.Options.EmptyValue(ZoomApiKeys.General.ClientSecret);
            }

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            var encodedString = Convert.ToBase64String(plainTextBytes);

            return $"{encodedString}"; 
        }
    }
}
