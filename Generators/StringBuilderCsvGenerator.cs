using System.Text;

namespace CsvGenerators.Generators;

public class StringBuilderCsvGenerator : ICsvGenerator
{
    public void Generate(SurveyData[] dataList, string fileName)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(
            "quarter , SER_REF , industry_code , industry_name , filled jobs , filled jobs revised , filled jobs diff , filled jobs % diff , total_earnings , total earnings revised , earnings diff , earnings % diff");

        foreach (var surveyData in dataList)
        {
            var row =
                $"{surveyData.Quarter},{surveyData.SerRef},{surveyData.IndustryCode},{surveyData.IndustryName},{surveyData.Filledjobs},{surveyData.Filledjobsrevised},{surveyData.FilledJobsDiff},{surveyData.FilledJobsPercentDiff},{surveyData.TotalEarnings},{surveyData.Totalearningsrevised},{surveyData.EarningsDiff},{surveyData.EarningsPercentDiff}";
            stringBuilder.AppendLine(row);
        }

        File.WriteAllText($".\\{fileName}.csv", stringBuilder.ToString());
    }
}