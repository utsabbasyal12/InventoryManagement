using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataAccess
{
    public interface IGenericRepository<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        Task<TResponse> GetByIdAsync(int id);
        Task<IReadOnlyList<TResponse>> GetAllAsync();
        Task<SystemResponse> AddAsync(TRequest request);
        Task<SystemResponse> UpdateAsync(TRequest request);
        Task<int> DeleteAsync(int id);  
    }
}
