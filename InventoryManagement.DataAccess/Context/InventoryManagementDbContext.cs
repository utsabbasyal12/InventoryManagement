using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DataAccess.Context
{
    public class InventoryManagementDbContext : DbContext
    {
        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
    }
}
