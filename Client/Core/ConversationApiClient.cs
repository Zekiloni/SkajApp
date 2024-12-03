using Shared.DTOs;
using System.Net.Http.Json;

namespace Client.Core
{
    public class ConversationApiClient
    {

        private readonly HttpClient _httpClient;

        private const string BasePath = "api/conversation";

        public ConversationApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponse> GetConversationAsync(CreateUserRequest request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(BasePath, request);
            return await DeserializeResponseAsync<UserResponse>(response);
        }
    }
}