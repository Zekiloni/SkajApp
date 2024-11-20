using Shared.DTOs;
using System.Net.Http.Json;

namespace Client.Core
{
    public class UserApiClient
    {
        private readonly HttpClient _httpClient;

        private const string BasePath = "api/user";
        private const string AuthApiPath = "/auth";

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponse> CreateUserAsync(CreateUserReq request)
        {
            HttpResponseMessage? response = await _httpClient.PostAsJsonAsync(BasePath, request); 
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserResponse>();
        }

        public async Task<UserAuthResponse> AuthUserAsync(UserAuthRequest request)
        {
            HttpResponseMessage? response = await _httpClient.PostAsJsonAsync(BasePath + AuthApiPath, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserAuthResponse>();
        }

        public async Task<UserResponse> RetrieveUserAsync(string userId)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(BasePath + "/" + userId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserResponse>();
        }
    }
}
