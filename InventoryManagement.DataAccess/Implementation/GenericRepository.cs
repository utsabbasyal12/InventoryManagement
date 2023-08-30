using InventoryManagement.DataAccess.Context;
using InventoryManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace InventoryManagement.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly InventoryManagementDbContext _context;

        public GenericRepository(InventoryManagementDbContext context)
        {
            _context = context;
        }
        public void AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id)!;
        }

        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
