using ContractSizeCalculator.Entities;
using ContractSizeCalculator.IO;
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
    public class CsvContractSizeDataProcessorTests
    {
        [TestMethod]
        public void DataProcessing_Success()
        {
            IContractSizeCalculator worker = new SimpleWorker();


            IDataProcessor processor = new CsvContractSizeDataProcessor(@"D:\GITHUB\ContractSizeCalculator\ContractSizeCalculator\Tests\DataExtractor_Example_Input.csv",
                @"D:\GITHUB\ContractSizeCalculator\ContractSizeCalculator\Tests\Output.csv", worker);

            processor.Process();

           

        }
    }
}
