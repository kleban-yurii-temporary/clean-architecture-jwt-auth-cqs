using EduTrack.Application.Authentication.Common;
using EduTrack.Application.Common.Interfaces.Authentication;
using EduTrack.Application.Common.Interfaces.Persistence;
using EduTrack.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Authentication.Queries.Login
{
    public class UserQueryHandler
         : IRequestHandler<UserQuery, ErrorOr<IEnumerable<User>>>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IEnumerable<User>>> Handle()
        {
            await Task.CompletedTask;
            
            return _userRepository.GetUserByEmailAsync();
        }

        public Task<ErrorOr<IEnumerable<User>>> Handle(object request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
