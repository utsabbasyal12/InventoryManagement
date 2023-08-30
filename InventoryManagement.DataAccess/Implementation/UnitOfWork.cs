using InventoryManagement.DataAccess.Context;
using InventoryManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryManagementDbContext _context;

        public UnitOfWork(InventoryManagementDbContext context)
        {
            _context = context;
            Wholesaler = new WholesalerRepository(_context);
            Category = new CategoryRepository(_context);
            Product = new ProductRepository(_context);
            ProductPrice = new ProductPriceRepository(_context);
            Stock = new StockRepository(_context);
        }
        public IWholesalerRepository Wholesaler { get; private set; }
        public ICategoryRepository Category{ get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductPriceRepository ProductPrice { get; private set; }
        public IStockRepository Stock { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
