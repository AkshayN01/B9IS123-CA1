using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Test
{
    public class APIClient
    {
        private HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private const string _identityServerUrl = "";
        public APIClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = new HttpClient();
        }

        public async Task<string> CallAPIAsync(string apiUrl, string token)
        {
            _httpClient.SetBearerToken(token);
            var response = await _httpClient.GetAsync($"{apiUrl}/protected-endpoint");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status code {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string?> GenerateToken()
        {
            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = $"{_identityServerUrl}/connect/token",
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Scope = "api_scope" // Scope required to access the API
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            return tokenResponse.AccessToken;
        }
    }
}
