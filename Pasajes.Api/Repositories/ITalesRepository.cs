using Pasajes.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pasajes.Api.Repositories
{
    public interface ITalesRepository
    {

        IEnumerable<Tale> GetTales();

        Tale GetTale(Guid taleId);

        TaleSource GetTaleSource(Guid taleSourceId);

        IEnumerable<TaleSource> GetTaleSources(Guid taleId);

        Task<int> CreateTaleAsync(Tale tale);

        Task<int> CreateTaleSourceAsync(TaleSource taleSource);
    }
}