using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class ItemWiseMonthlySalesReportDTO
    {
        public string itemName { get; set; }
        public string CustomerName { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal ItemQuantity { get; set; }

    }
}
