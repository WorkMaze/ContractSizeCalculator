using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSizeCalculator.Entities
{
    public class Contract
    {
        public string ISIN { get; set; }
        public string CFICode { get; set; }
        public string Venue { get; set; }
        public decimal ContractSize { get; set; }
    }
}
