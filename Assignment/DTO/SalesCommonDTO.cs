using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DTO
{
    public class SalesCommonDTO
    {
        public SalesDTO header { get; set; }
        public SalesDetailsDTO row { get; set; }
       // public List<SalesDetailsDTO> row { get; set; }

    }
}
