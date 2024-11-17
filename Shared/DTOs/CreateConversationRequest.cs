
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class CreateConversationRequest
    {
        [Required]
        public required Guid SenderId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Content { get; set; }

        [Required]
        public required IEnumerable<string> Recipients { get; set; }
    }
}
