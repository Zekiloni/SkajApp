namespace Shared.DTOs
{
    public class UserAuthResponse
    {

        public string Token { get; private set; }
        public UserResponse User { get; private set; }

        public UserAuthResponse(string token, UserResponse user)
        {
            Token = token;
            User = user;
        }
    }
}
