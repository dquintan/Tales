using Pasajes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pasajes.Contracts
{
    public interface ITalesService
    {
        Task<IEnumerable<Tale>> GetAllTales();
    }
}
