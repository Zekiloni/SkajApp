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

        public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(BasePath, request);
            return await DeserializeResponseAsync<UserResponse>(response);
        }

        public async Task<UserAuthResponse> AuthUserAsync(UserAuthRequest request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(BasePath + AuthApiPath, request);
            return await DeserializeResponseAsync<UserAuthResponse>(response);
        }

        public async Task<UserResponse> RetrieveUserAsync(string userId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(BasePath + "/" + userId);
            return await DeserializeResponseAsync<UserResponse>(response);
        }

        private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>()
                   ?? throw new InvalidOperationException("Failed to deserialize the response.");
        }
    }
}
