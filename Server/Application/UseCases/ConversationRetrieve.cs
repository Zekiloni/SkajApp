using AutoMapper;
using Server.Core.Entities;
using Server.Infrastructure.Utilities;
using Server.Ports.Inbound;
using Shared.DTOs;

namespace Server.Application.UseCases
{
    public class ConversationRetrieve
    {
        private readonly IConversationService _conversationService;
        private readonly IMapper _mapper;

        public ConversationRetrieve(IConversationService conversationService, IMapper mapper)
        {
            _conversationService = conversationService;
            _mapper = mapper;
        }


        public async Task<ConversationResponse> Handle(string conversationId)
        {
            Conversation? conversation = await _conversationService.GetConversationById(GuidUtils.Parse(conversationId));

            return null;
        }
    }
}
