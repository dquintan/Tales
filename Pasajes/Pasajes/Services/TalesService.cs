using Akavache;
using Pasajes.Constants;
using Pasajes.Models;
using Pasajes.Repository;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Pasajes.Services
{
    public class TalesService : BaseService
    {
        private IGenericRepository _genericRepository;

        public TalesService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Tale>> GetAllTales()
        {
            List<Tale> talesFromCache = await GetFromCache<List<Tale>>(CacheNameConstants.AllTales);

            if (talesFromCache != null)
            {
                return talesFromCache;
            }
            else
            {
                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.TalesCatalog
                };

                
                var tales = await _genericRepository.GetAsync<List<Tale>>(builder.ToString(), "");
                await Cache.InsertObject(CacheNameConstants.AllTales, tales, DateTimeOffset.Now.AddSeconds(20));

                return tales;
            }
        }
    }
}
