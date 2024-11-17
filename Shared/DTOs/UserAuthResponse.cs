namespace Shared.DTOs
{
    public class UserAuthResponse
    {
        public required string Token { get; set; }
        public required UserResponse User { get; set; }
    }
}
