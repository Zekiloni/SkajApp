using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Core.Entities
{
    [Table("user_conversation")]
    public class UserConversation
    {
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public required User User { get; set; }

        public Guid ConversationId { get; set; }

        [ForeignKey("ConversationId")]
        public required Conversation Conversation { get; set; }

    }
}
