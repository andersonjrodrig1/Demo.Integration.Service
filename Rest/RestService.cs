using Demo.Integration.Service.Interfaces.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> GetAsync(string url, Dictionary<string, string> headers, string mediaType) =>
            await ExecuteAsync(HttpMethod.Get, mediaType, headers, url);

        private async Task<string> ExecuteAsync(HttpMethod method, string mediaType, Dictionary<string, string> headers, string url, string body = null)
        {
            var request = new HttpRequestMessage();
            request.Method = method;
            request.Headers.Add("Accept", "*/*");

            if (headers != null && headers.Any())
            {
                foreach (KeyValuePair<string, string> keyValue in headers)
                {
                    request.Headers.Add(keyValue.Key, keyValue.Value);
                }
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://viacep.com.br/");
            client.DefaultRequestHeaders.Add("Accept", mediaType);

            var response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }

        #region Dispose

        public void Dispose()
        {
        }

        #endregion
    }
}
