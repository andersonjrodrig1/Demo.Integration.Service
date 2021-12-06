using Demo.Integration.Service.Interfaces.Rest;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Rest
{
    public class RestService : IRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAsync(string url, string mediaType, Dictionary<string, string> headers = null) => 
            await ExecuteAsync(HttpMethod.Get, url, mediaType, headers);

        private async Task<string> ExecuteAsync(HttpMethod method, string url, string mediaType, Dictionary<string, string> headers = null, string body = null)
        {
            var result = string.Empty;

            try
            {
                var request = new HttpRequestMessage(method, url)
                {
                    Headers = { { HeaderNames.Accept, mediaType } }
                };

                using (var client = _httpClientFactory.CreateClient())
                {
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"Status Code: {response.StatusCode.GetHashCode()}, Content: {response.Content.ReadAsStringAsync().Result}");

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var read = new StreamReader(stream);
                        result = read.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #region Dispose

        public void Dispose()
        {
        }

        #endregion
    }
}
