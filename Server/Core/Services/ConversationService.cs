using Server.Adapters.Outbound;
using Server.Core.Entities;
using Server.Ports.Inbound;

namespace Server.Core.Services
{
    public class ConversationService : IConversationService
    {
        private readonly ConversationRepository _conversationRepository;

        public ConversationService(ConversationRepository conversationRepository)
        {
            this._conversationRepository = conversationRepository;
        }

        public Task<Conversation> CreateConversation(Conversation conversation)
        {
            throw new NotImplementedException();
        }

        public Task<Conversation?> GetConversationById(Guid conversationId)
        {
            throw new NotImplementedException();
        }

        public Task<Conversation> UpdateConversation(Conversation conversatiom)
        {
            throw new NotImplementedException();
        }
    }
}
