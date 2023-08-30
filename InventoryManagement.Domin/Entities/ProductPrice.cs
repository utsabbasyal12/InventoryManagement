using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    [Table("tblProductPrices")]
    public class ProductPrice
    {
        [Key]
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public int WholesalerId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
