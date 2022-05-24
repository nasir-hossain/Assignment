using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class SalesDetailsDTO
    {
        public long IntSalesId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
    }
}
