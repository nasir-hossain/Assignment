using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class ItemDTO
    {
        public long IntItemId { get; set; }
        public string StrItemName { get; set; }
        public decimal NumStockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
