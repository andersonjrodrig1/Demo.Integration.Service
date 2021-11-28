using Demo.Integration.Service.Entities;
using System;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Interfaces.Services
{
    public interface IViaCepService : IDisposable
    {
        Task<ViaCep> GetDataByCep(string cep);
    }
}
