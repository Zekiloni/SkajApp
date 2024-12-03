
namespace Shared.DTOs
{
    public class ConversationResponse
    {
        public required string ConversationId { get; set; }

        public string? Name {  get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<UserResponse> Members { get; set; } = new List<UserResponse>();
    }
}
