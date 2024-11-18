using AutoMapper;
using Server.Core.Entities;
using Server.Infrastructure.Security;
using Server.Ports.Inbound;
using Shared.DTOs;

namespace Server.Application.UseCases
{
    public class UserAuth
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly JwtTokenService _jwtTokenService;

        public UserAuth(IMapper mapper, IUserService userService, JwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<UserAuthResponse> Handle(UserAuthRequest userAuthRequest)
        {
            User? user = await _userService.GetUserByUsername(userAuthRequest.Username);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            if (!_userService.ValidatePassword(user, userAuthRequest.Password))
                throw new UnauthorizedAccessException("Incorrect password");

            _userService.UpdateLastLogin(user);
            await _userService.UpdateUser(user);

            return new UserAuthResponse(_jwtTokenService.GenerateToken(user), _mapper.Map<UserResponse>(user));
        }
    }
}
