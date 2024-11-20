
using Server.Core.Entities;
using Server.Ports.Inbound;
using Shared.DTOs;

namespace Server.Application.UseCases
{
    public class ConversationCreate
    {
        private readonly IUserService _userService;

        public ConversationCreate(IUserService userService)
        {
            _userService = userService;
        }

        public async void Handle(CreateConversationRequest conversationRequest)
        {
            List<Task<User?>>? userTasks = conversationRequest.Recipients
            .Select(username => _userService.GetUserByUsername(username))
            .ToList();

            User?[]? users = await Task.WhenAll(userTasks);

            List<User?>? validUsers = users.Where(user => user != null).ToList();
        }

    }
}
