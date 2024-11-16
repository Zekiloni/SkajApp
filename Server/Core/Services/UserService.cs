using Server.Ports.Inbound;

namespace Server.Core.Services
{
    public class UserService : IUserService
    {
        Task<User> IUserService.CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.UpdateUser(Guid userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
