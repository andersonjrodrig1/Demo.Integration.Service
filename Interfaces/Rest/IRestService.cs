using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Integration.Service.Interfaces.Rest
{
    public interface IRestService : IDisposable
    {
        Task<string> GetAsync(string url, string mediaType, Dictionary<string, string> headers = null);
    }
}
