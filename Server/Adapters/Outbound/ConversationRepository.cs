
using Server.Core.Entities;
using Server.Ports.Outbound;
using Server.Infrastructure.Persistence;

namespace Server.Adapters.Outbound
{
    public class ConversationRepository : IRepository<Conversation, Guid>
    {

        private readonly DatabaseContext _context;

        public ConversationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Conversation conversation)
        {
            await _context.Conversations.AddAsync(conversation);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conversation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Conversation?> GetByIdAsync(Guid id)
        {
            return await _context.Conversations.FindAsync(id);
        }

        public Task UpdateAsync(Conversation entity)
        {
            throw new NotImplementedException();
        }
    }
}
