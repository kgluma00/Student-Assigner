using SA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sa.Repository
{
    public class SaRepository : ISaRepository
    {
        private readonly ApplicationContext _applicationContext;
        public SaRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }

        public async Task<int> AddAsyncEntity<T>(List<T> entites) where T : class
        {
            foreach (var el in entites)
            {
                _applicationContext.Add(el);
            }

            return await _applicationContext.SaveChangesAsync();
        }
    }
}
