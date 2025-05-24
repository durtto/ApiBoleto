using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HttpClienteApi.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly ILogger<AuthService> _logger;
        private string _accessToken;
        private DateTime _tokenExpiration;

        public AuthService(HttpClient httpClient, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
            _logger = logger;
        }

        public async Task<string> GetAccessToken()
        {
            try
            {
                // Verifica se o token atual ainda é válido
                if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _tokenExpiration)
                {
                    return _accessToken;
                }

                _logger.LogInformation("Solicitando novo token de acesso...");
                
                // Chama o endpoint do TokenController
                var response = await _httpClient.PostAsync($"{_baseUrl}/token", null);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter token. Status: {response.StatusCode}. Conteúdo: {errorContent}");
                    throw new Exception($"Erro ao obter token: {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);

                _accessToken = tokenResponse.AccessToken;
                _tokenExpiration = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 60); // Subtrai 60 segundos para renovar antes de expirar

                _logger.LogInformation("Novo token obtido com sucesso");
                return _accessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter token: {ex.Message}");
                throw;
            }
        }

        private class TokenResponse
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }

            [JsonPropertyName("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }
        }
    }
} 