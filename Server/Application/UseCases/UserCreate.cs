using AutoMapper;
using Server.Core.Entities;
using Server.Ports.Inbound;
using Shared.DTOs;

namespace SkajApp.ApiService.Application.UseCases
{
    public class UserCreate
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserCreate(IMapper mapper, IUserService userService) {
            _mapper = mapper;
            _userService = userService; 
        }

        public async Task<UserResponse> Handle(CreateUserRequest createUserRequest)
        {
            User user = await _userService.CreateUser(_mapper.Map<User>(createUserRequest));
            return _mapper.Map<UserResponse>(user);
        }
    }
}
