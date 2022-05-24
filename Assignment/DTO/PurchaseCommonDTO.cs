using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class PurchaseCommonDTO
    {
        public PurchaseDTO header { get; set; }
        public PurchaseDetailsDTO row { get; set; }
        //public List<PurchaseDetailsDTO> row { get; set; }
    }
}