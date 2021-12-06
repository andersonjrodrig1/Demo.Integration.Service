using Demo.Integration.Service.Entities;
using System;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Interfaces.Services
{
    public interface IViaCepService : IDisposable
    {
        Task<ViaCep> GetDataByCepJson(string cep);
        Task<ViaCep> GetDataByCepXml(string cep);
    }
}
