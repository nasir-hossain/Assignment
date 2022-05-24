using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Assignment.Models.Read
{
    public partial class TblSalesDetails
    {
        public long IntDetailsId { get; set; }
        public long IntSalesId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumItemQuantity { get; set; }
        public decimal? NumUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
