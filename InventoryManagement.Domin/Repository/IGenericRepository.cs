using Shared.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Repository
{
    public interface IGenericRepository<T>
        where T : class
    {
        T GetByIdAsync(int id);
        IEnumerable<T> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void AddAsync(T entity);
        void AddRangeAsync(IEnumerable<T> entities);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
