using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Username)
                        .IsUnique();

            modelBuilder.Entity<UserConversation>()
              .HasKey(ug => new { ug.UserId, ug.ConversationId }); 

            modelBuilder.Entity<UserConversation>()
                        .HasOne(ug => ug.User)
                        .WithMany(u => u.UserConversations)
                        .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserConversation>()
                        .HasOne(ug => ug.Conversation)
                        .WithMany(g => g.UserConversations)
                        .HasForeignKey(ug => ug.ConversationId);

            modelBuilder.Entity<Conversation>()
                        .HasIndex(g => g.Name)
                        .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
