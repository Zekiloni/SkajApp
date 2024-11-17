using Server.Adapters.Outbound;
using Server.Core.Entities;
using Server.Ports.Inbound;

namespace Server.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }


        async Task<User> IUserService.CreateUser(User user)
        {
            await _userRepository.CreateAsync(user);
            return user;
        }

        async Task<User?> IUserService.GetUserById(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        async Task<User> IUserService.UpdateUser(User user)
        {
            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}
