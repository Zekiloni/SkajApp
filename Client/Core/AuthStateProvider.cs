using Blazored.LocalStorage;
using Client.Core.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Client.Core
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
                return _anonymous;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(Utils.JwtParser.ParseClaimsFromJwt(token), "jwt")));
        }

        public void NotifyUserAuthentication(string token)
        {
            ClaimsPrincipal? authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt"));
            Task<AuthenticationState>? authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            Task<AuthenticationState>? authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
