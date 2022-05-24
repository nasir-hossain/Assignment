﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Assignment.Models.Write
{
    public partial class TblPurchaseDetails
    {
        public long IntDetailsId { get; set; }
        public long IntPurchaseId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumItemQuantity { get; set; }
        public decimal NumUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
