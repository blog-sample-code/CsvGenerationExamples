using System.Globalization;
using System.Text;
using CsvHelper;

namespace CsvGenerators.Generators;

public class CsvHelperCsvGenerator : ICsvGenerator
{
    public void Generate(SurveyData[] dataList, string fileName)
    {
        using (var memoryStream = File.OpenWrite($".\\{fileName}.csv"))
        {
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(dataList);
                    csvWriter.Flush();
                }
            }
        }
    }
}