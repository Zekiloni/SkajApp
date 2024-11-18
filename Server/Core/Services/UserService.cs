using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        async Task<User> IUserService.CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.LastLoginAt = null;
            user.UserConversations = new List<UserConversation>();

            HashPassword(user, user.Password);

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

        private void HashPassword(User user, string password)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePassword(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public void UpdateLastLogin(User user)
        {
            user.LastLoginAt = DateTime.UtcNow;
        }
    }
}
