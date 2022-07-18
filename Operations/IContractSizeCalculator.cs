using ContractSizeCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSizeCalculator.Operations
{
    public interface IContractSizeCalculator
    {
        IEnumerable<Contract> GetContractSize(IEnumerable<StockMarketTransaction> transactions);
    }
}
