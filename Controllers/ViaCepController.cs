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
        public async Task<ViaCep> GetDataByCep(string cep, [FromServices] IViaCepService services)
        {
            return await services.GetDataByCep(cep);
        }
    }
}
