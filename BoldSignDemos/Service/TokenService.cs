using BoldSign.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BoldSign.Demos.Service
{
    public class TokenService
    {
        private readonly HttpClient httpClient;
        private readonly ApiClient apiClient;
        private static string accessToken = null;
        private static DateTime? expiresAt = null;

        public TokenService(HttpClient httpClient, ApiClient apiClient)
        {
            this.httpClient = httpClient;
            this.apiClient = apiClient;
        }

        public async Task SetTokenAsync()
        {
            if (accessToken != null && expiresAt != null && expiresAt > DateTime.UtcNow.AddMinutes(-5))
            {
                // added accesstoken in default header.
                this.apiClient.Configuration.DefaultHeader.TryAdd("Authorization", "Bearer " + accessToken);
            }
            else
            {
                // need to add required scopes.
                var parameters = new List<KeyValuePair<string, string>>
                        {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("scope", "BoldSign.Documents.All BoldSign.Templates.All")
                        };

                using var encodedContent = new FormUrlEncodedContent(parameters);

                using var request = new HttpRequestMessage()
                {
                    Content = encodedContent,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://account.boldsign.com/connect/token"),
                };

                //client id for get access token
                string clientId = Environment.GetEnvironmentVariable("ClientID");

                //client secret for get access token
                string clientSecret = Environment.GetEnvironmentVariable("ClientSecret");

                var encodedAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedAuth);

                //send request for fetch access token
                using var response = await this.httpClient.SendAsync(request).ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                tokenResponse.TryGetValue("access_token", out accessToken);
                tokenResponse.TryGetValue("expires_in", out var expiresIn);
                expiresAt = DateTime.UtcNow.AddSeconds(Convert.ToInt32(expiresIn));

                this.apiClient.Configuration.DefaultHeader.Remove("Authorization");

                // added accesstoken in default header.
                this.apiClient.Configuration.DefaultHeader.TryAdd("Authorization", "Bearer " + accessToken);
            }
        }
    }
}
