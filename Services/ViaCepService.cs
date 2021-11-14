using Demo.Integration.Service.Interfaces.Rest;
using Demo.Integration.Service.Interfaces.Services;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly IRestService _restService;

        public ViaCepService(IRestService restService)
        {
            _restService = restService;
        }

        public Task<string> GetDataByCep(string cep)
        {
            var baseUrl = "http://viacep.com.br/";
            var url = "/ws/96180000/json/";

            var test = _restService.GetAsync(url, null, "application/json");

            return test;
        }

        #region Dispose

        public void Dispose()
        {
        }

        #endregion
    }
}
