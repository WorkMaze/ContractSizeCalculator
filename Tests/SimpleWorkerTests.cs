using ContractSizeCalculator.Entities;
using ContractSizeCalculator.Operations;
using ContractSizeCalculator.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSizeCalculator.Tests
{
    [TestClass]
    public class SimpleWorkerTests
    {
        [TestMethod]
        public void Valid_Transaction_Calculate_Success()
        {
            IContractSizeCalculator worker = new SimpleWorker();

            var transactions = new List<StockMarketTransaction>() {
                new StockMarketTransaction()
                {
                    ISIN = "DE000ABCDEFG",
                    CFICode ="FFICSX",
                    Venue = "XEUR",
                    AlgoParams = "InstIdentCode:DE000ABCDEFG|;InstFullName:DAX|;InstClassification:FFICSX|;NotionalCurr:EUR|;PriceMultiplier:20.0|;UnderlInstCode:DE0001234567|;UnderlIndexName:DAX PERFORMANCE-INDEX|;OptionType:OTHR|;StrikePrice:0.0|;OptionExerciseStyle:|;ExpiryDate:2021-01-01|;DeliveryType:PHYS|"
                },
                new StockMarketTransaction()
                {
                    ISIN = "L0ABCDEFGHI",
                    CFICode ="FFICSX",
                    Venue = "WDER",
                    AlgoParams = "InstIdentCode:PL0ABCDEFGHI|;InstFullName:Wig 20 Index|;InstClassification:FFICSX|;NotionalCurr:PLN|;PriceMultiplier:25.0|;UnderlInstCode:PL9991234567|;UnderlIndexName:WIG20 PLN|;OptionType:OTHR|;StrikePrice:0.0|;OptionExerciseStyle:|;ExpiryDate:2021-01-01|;DeliveryType:PHYS|"
                }
            };
           

            var contracts = worker.GetContractSize(transactions);
            Assert.AreEqual(contracts.Count(), 2);
            Assert.AreEqual(contracts.ToList()[0].ContractSize, 20.0M); ;
            Assert.AreEqual(contracts.ToList()[1].ContractSize, 25.0M); ;

        }
    }
}
