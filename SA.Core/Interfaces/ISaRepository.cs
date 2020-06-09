using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SA.Core.Interfaces
{
    public interface ISaRepository
    {
        Task<int> AddAsyncEntity<T>(List<T> entites) where T : class;
    }
}
