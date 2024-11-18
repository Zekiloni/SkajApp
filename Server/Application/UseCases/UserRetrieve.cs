using AutoMapper;
using Server.Core.Entities;
using Server.Infrastructure.Utilities;
using Server.Ports.Inbound;
using Shared.DTOs;

namespace Server.Application.UseCases
{
    public class UserRetrieve
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserRetrieve(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserResponse> Handle(string userId)
        {
            User? user = await _userService.GetUserById(GuidUtils.Parse(userId));

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            return _mapper.Map<UserResponse>(user);
        }
    }
}
