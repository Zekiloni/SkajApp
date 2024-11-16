using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public required string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(128)]
        public required string Password { get; set; }
    }
}
