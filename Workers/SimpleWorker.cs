using ContractSizeCalculator.Entities;
using ContractSizeCalculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSizeCalculator.Workers
{
    internal class SimpleWorker : IContractSizeCalculator //Other interfaces too
    {
        internal SimpleWorker()
        {
            
        }

        #region Operations
        public IEnumerable<Contract> GetContractSize(IEnumerable<StockMarketTransaction> transactions)
        {
            var contracts = new List<Contract>();

            foreach (var transaction in transactions)
            {

                var contract = new Contract();

                contract.ISIN = transaction.ISIN;
                contract.CFICode = transaction.CFICode;
                contract.Venue = transaction.Venue;
                contract.ContractSize = GetContractSizeFromAlgoParams(transaction.AlgoParams);
                contracts.Add(contract);
            }

            return contracts;
        }
        #endregion

        #region PrivateMethods
        private decimal GetContractSizeFromAlgoParams(string algoParams)
        {
            decimal size = 0.0M;

            if (algoParams != null)
            {
                var splittedAlgoParams = algoParams.Split('|');

                if(splittedAlgoParams.Length > 0)
                {
                    foreach(var algoParam in splittedAlgoParams)
                    {
                        if(algoParam.Contains("PriceMultiplier"))
                        {
                            var splittedPriceMultiplerString = algoParam.Split(':');

                            if(splittedPriceMultiplerString.Length > 0)
                            {
                                var sizeString = splittedPriceMultiplerString[1];
                                decimal.TryParse(sizeString, out size);                               
                            }
                        }
                    }
                }
            }

            return size;
        }
        #endregion
    }
}
