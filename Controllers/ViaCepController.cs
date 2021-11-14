using Demo.Integration.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Controllers
{
    public class ViaCepController
    {
        [HttpGet]
        [Route("api/v1/{cep}/cep")]
        public async Task<string> GetDataByCep(string cep, [FromServices] IViaCepService services)
        {
            return await services.GetDataByCep(cep);
        }
    }
}
