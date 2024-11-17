using Server.Core.Entities;

namespace Server.Ports.Inbound
{
    public interface IConversationService
    {
        public Task<Conversation> CreateConversation(Conversation conversation);

        public Task<Conversation?> GetConversationById(Guid conversationId);

        public Task<Conversation> UpdateConversation(Conversation conversatiom);
    }
}
