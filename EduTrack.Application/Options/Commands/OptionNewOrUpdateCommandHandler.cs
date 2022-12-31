﻿using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Application.Options.Commands;
using EduTrack.Application.Options.Queries.GetOptions;
using EduTrack.Application.Users.Queries.GetUser;
using EduTrack.Domain.AppErrors;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Specialities.Queries.GetOptions
{
    public class OptionNewOrUpdateCommandHandler : IRequestHandler<OptionNewOrUpdateCommand, ErrorOr<Option>>
    {
        private readonly IOptionsRepository optionsRepository;
        private readonly IUserRepository userRepository;

        public OptionNewOrUpdateCommandHandler(
            IOptionsRepository optionsRepository, 
            IUserRepository userRepository)
        {
            this.optionsRepository = optionsRepository;
            this.userRepository= userRepository;
        }

        public async Task<ErrorOr<Option>> Handle(OptionNewOrUpdateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            Option option = await optionsRepository.GetByKeyAsync(request.Key, request.UserId);

            if(option is not null)
            {
                option = await optionsRepository.GetByKeyAsync(request.Key);
                option.Value = request.Value;
                option.Group = request.Group;
                option = await optionsRepository.UpdateAsync(option, request.UserId);
            }
            else
            {
                option = new Option
                {
                    Key = request.Key.Trim().ToLower(),
                    Group = request.Group,
                    Value = request.Value
                };

                if(request.UserId is not null)
                {
                    var user = await userRepository.GetUserAsync((Guid)request.UserId);
                    if (user is null) return Errors.User.NotFound;
                }

                option = await optionsRepository.AddAsync(option, request.UserId);
            }

            return option;
        }
    }
}