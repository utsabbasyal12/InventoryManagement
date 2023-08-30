using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    [Table("tblCategories")]
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
