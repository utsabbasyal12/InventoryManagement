using InventoryManagement.DataAccess.Context;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DataAccess.Implementation
{
    public class WholesalerRepository : GenericRepository<Wholesaler>, IWholesalerRepository
    {
        public WholesalerRepository(InventoryManagementDbContext context) : base(context)
        {

        }
    }
}
