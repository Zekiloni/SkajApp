using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Core.Entities
{
    [Table("conversations")]
    public class Conversation
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Column("description")]
        [MaxLength(128)]
        public string Description { get; private set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; private set; }

        public ICollection<UserConversation> UserConversations { get; private set; }

        public Conversation(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UserConversations = new List<UserConversation>();
        }

        public void AddUser(User user)
        {
            UserConversations.Add(new UserConversation { User = user, Conversation = this });
        }
    }
}