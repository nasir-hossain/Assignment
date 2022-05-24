﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class SupplierWiseDailyPurchaseReportDTO
    {
        public string itemName { get; set; }
        public string SupplierName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal ItemQuantity { get; set; }
    }
}
