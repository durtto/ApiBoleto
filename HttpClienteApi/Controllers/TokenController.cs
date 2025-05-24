using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;
using HttpClienteApi.Models;

namespace HttpClienteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TokenController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> GetToken()
        {
            // Dados fixos
            var clientId = "eyJpZCI6IjYxMzhkOTctNWNkNi00NTNiLTk4YTMtNDRkOTZlIiwiY29kaWdvUHVibGljYWRvciI6MCwiY29kaWdvU29mdHdhcmUiOjEzNTQxMCwic2VxdWVuY2lhbEluc3RhbGFjYW8iOjF9";
            var appKey = "c2bf835ff33e4e4697d2566ebb454f86";
            var clientSecret = "eyJpZCI6ImUwYmVhZTMtY2YyOS00MmIxLTk0MjMtYjBmNjU2YTYiLCJjb2RpZ29QdWJsaWNhZG9yIjowLCJjb2RpZ29Tb2Z0d2FyZSI6MTM1NDEwLCJzZXF1ZW5jaWFsSW5zdGFsYWNhbyI6MSwic2VxdWVuY2lhbENyZWRlbmNpYWwiOjEsImFtYmllbnRlIjoiaG9tb2xvZ2FjYW8iLCJpYXQiOjE3NDc5MzM4NjM5Nzl9";
            var basic = "ZXlKcFpDSTZJall4TXpoa09UY3ROV05rTmkwME5UTmlMVGs0WVRNdE5EUmtPVFpsSWl3aVkyOWthV2R2VUhWaWJHbGpZV1J2Y2lJNk1Dd2lZMjlrYVdkdlUyOW1kSGRoY21VaU9qRXpOVFF4TUN3aWMyVnhkV1Z1WTJsaGJFbHVjM1JoYkdGallXOGlPakY5OmV5SnBaQ0k2SW1Vd1ltVmhaVE10WTJZeU9TMDBNbUl4TFRrME1qTXRZakJtTmpVMllUWWlMQ0pqYjJScFoyOVFkV0pzYVdOaFpHOXlJam93TENKamIyUnBaMjlUYjJaMGQyRnlaU0k2TVRNMU5ERXdMQ0p6WlhGMVpXNWphV0ZzU1c1emRHRnNZV05oYnlJNk1Td2ljMlZ4ZFdWdVkybGhiRU55WldSbGJtTnBZV3dpT2pFc0ltRnRZbWxsYm5SbElqb2lhRzl0YjJ4dloyRmpZVzhpTENKcFlYUWlPakUzTkRjNU16TTROak01TnpsOQ==";

// ...existing code...
            var uri = new System.Uri("https://oauth.hm.bb.com.br/oauth/token");
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basic);

            var content = new StringContent(
                $"grant_type=client_credentials&client_id={clientId}&appKey={appKey}&client_secret={clientSecret}",
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );
            request.Content = content;

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, responseBody);
            }

            return Ok(responseBody);
        }
    }
}
