
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Core.Entities
{
    [Table("users")]
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; }

        [Required]
        [Column("username")]
        [MaxLength(50)]
        public string Username { get; private set; }

        [Required]
        [Column("password")]
        public string Password { get; private set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; private set; }

        [Column("last_login_at")]
        public DateTime? LastLoginAt { get; private set; }

        public ICollection<UserConversation> UserConversations { get; private set; }


        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = HashPassword(password);
            CreatedAt = DateTime.UtcNow;
            LastLoginAt = null;
            UserConversations = new List<UserConversation>();
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = HashPassword(newPassword);
        }

        public void UpdateLastLogin()
        {
            LastLoginAt = DateTime.UtcNow;
        }
    }
}
