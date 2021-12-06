using Demo.Integration.Service.Entities;
using Demo.Integration.Service.Interfaces.Rest;
using Demo.Integration.Service.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo.Integration.Service.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly IRestService _restService;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public ViaCepService(IRestService restService, IConfiguration configuration, ILogger<ViaCepService> logger)
        {
            _restService = restService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ViaCep> GetDataByCepJson(string cep)
        {
            var baseUrl = _configuration.GetSection("ExternalEndpoint:ViaCep:BaseUrl").Get<string>();
            var path = string.Format("/ws/{0}/json/", cep);
            var mediaType = _configuration.GetSection("MediaType:Json").Get<string>();

            var url = string.Concat(baseUrl, path);

            _logger.LogInformation($"{this.GetType().Name} - {MethodInfo.GetCurrentMethod().Name} - Request: {url}");

            var response = await _restService.GetAsync(url, mediaType);

            _logger.LogInformation($"{this.GetType().Name} - {MethodInfo.GetCurrentMethod().Name} - Response: {response}");

            return JsonConvert.DeserializeObject<ViaCep>(response);
        }

        public async Task<ViaCep> GetDataByCepXml(string cep)
        {
            var baseUrl = _configuration.GetSection("ExternalEndpoint:ViaCep:BaseUrl").Get<string>();
            var path = string.Format("/ws/{0}/xml/", cep);
            var mediaType = _configuration.GetSection("MediaType:Json").Get<string>();

            var url = string.Concat(baseUrl, path);

            _logger.LogInformation($"{this.GetType().Name} - {MethodInfo.GetCurrentMethod().Name} - Request: {url}");

            var response = await _restService.GetAsync(url, mediaType);

            _logger.LogInformation($"{this.GetType().Name} - {MethodInfo.GetCurrentMethod().Name} - Response: {response}");

            var xDocument = XDocument.Parse(response);
            var jsonDocument = JsonConvert.SerializeXNode(xDocument);
            dynamic viaCep = JsonConvert.DeserializeObject<ViaCep>(jsonDocument);

            return viaCep;
        }

        #region Dispose

        public void Dispose()
        {
        }

        #endregion
    }
}
