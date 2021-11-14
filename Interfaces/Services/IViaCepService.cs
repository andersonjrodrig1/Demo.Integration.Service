using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Interfaces.Services
{
    public interface IViaCepService : IDisposable
    {
        Task<string> GetDataByCep(string cep);
    }
}
