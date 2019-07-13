using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pasajes.Api.Entities;
using Pasajes.Api.Models;

namespace Pasajes.Api.Repositories
{
    public class TalesRepository : ITalesRepository
    {
        private readonly TalesContext _context;

        public TalesRepository(TalesContext context)
        {
            _context = context;
        }

        public Tale GetTale(Guid taleId)
        {
            return _context.Tales.FirstOrDefault(t => t.Id == taleId);
        }

        public IEnumerable<Tale> GetTales()
        {
            return _context.Tales.OrderBy(t => t.Year).ToList();
        }

        public TaleSource GetTaleSource(Guid taleSourceId)
        {
            return _context.TaleSources.FirstOrDefault(t => t.Id == taleSourceId);
        }

        public IEnumerable<TaleSource> GetTaleSources(Guid taleId)
        {
            return _context.TaleSources.Where(t => t.TaleId == taleId).OrderBy(t => t.Priority).ToList();
        }

        public async Task<int> CreateTaleAsync(Tale tale)
        {
            await _context.AddAsync(tale);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateTaleSourceAsync(TaleSource taleSource)
        {
            await _context.AddAsync(taleSource);
            return await _context.SaveChangesAsync();
        }

    }
}
