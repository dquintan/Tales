using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pasajes.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri, string authToken);
    }
}
