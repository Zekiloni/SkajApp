using Server.Core.Entities;

namespace Server.Ports.Inbound
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);

        public Task<User?> GetUserById(Guid userId);

        public Task<User> UpdateUser(User user);
    }
}
