using Demo.Integration.Service.Entities;
using Demo.Integration.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Controllers
{
    [ApiController]
    [Route("api/viacep")]
    public class ViaCepController
    {
        [HttpGet]
        [Route("v1/{cep}/cep/json")]
        public async Task<ViaCep> GetDataByCepJson(string cep, [FromServices] IViaCepService services)
        {
            return await services.GetDataByCepJson(cep);
        }

        [HttpGet]
        [Route("v1/{cep}/cep/xml")]
        public async Task<ViaCep> GetDataByCepXml(string cep, [FromServices] IViaCepService services)
        {
            return await services.GetDataByCepXml(cep);
        }
    }
}
