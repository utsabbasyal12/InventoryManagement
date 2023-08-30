using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    [Table("tblStocks")]
    public class Stocks
    {
        [Key]
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int WholesalerId { get; set; }
        public int StockQuantity { get;set; } 
    }
}
