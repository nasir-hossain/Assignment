using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class PurchaseDetailsDTO
    {
        public long IntPurchaseId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumItemQuantity { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal NumUnitPrice { get; set; }
    }
}
