namespace Shared.DTOs
{
    public class UserAuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAuthRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
