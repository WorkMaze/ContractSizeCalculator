using ContractSizeCalculator.Entities;
using ContractSizeCalculator.Operations;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSizeCalculator.IO
{
    internal class CsvContractSizeDataProcessor : IDataProcessor
    {
        private string _inputFilePath;
        private string _outputFilePath;
        private IContractSizeCalculator _contractSizeCalculator;
        internal CsvContractSizeDataProcessor(string inputFilePath,string outputFilePath, IContractSizeCalculator contractSizeCalculator)
        {
            _inputFilePath = inputFilePath;
            _contractSizeCalculator = contractSizeCalculator;
            _outputFilePath = outputFilePath;
        }
        public void Process()
        {
            var textReader = new StreamReader(_inputFilePath);
            var csvReader = new CsvReader(textReader, System.Globalization.CultureInfo.CurrentCulture);

            var transactions =  csvReader.GetRecords<StockMarketTransaction>();

            var contracts = _contractSizeCalculator.GetContractSize(transactions);
            var writer = new StreamWriter(_outputFilePath);


            // For some reason CSVHelper WriteRecord ws creating empty files
            writer.WriteLine(String.Format("{0},{1},{2},{3}", "ISIN", "CFICode", "Venue", "ContractSize"));
            foreach(var contract in contracts)
            {
                writer.WriteLine(string.Format("{0},{1},{2},{3}", contract.ISIN, contract.CFICode, contract.Venue, contract.ContractSize));
            }
            writer.Close();
          


        }
    }
}
