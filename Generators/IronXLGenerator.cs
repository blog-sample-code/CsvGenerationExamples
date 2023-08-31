using IronXL;

namespace CsvGenerators.Generators;

public class IronXLGenerator : ICsvGenerator
{
    public void Generate(SurveyData[] dataList, string fileName)
    {
        WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
        var workSheet = workBook.DefaultWorkSheet;

        var cellValues = new[]
        {
            "quarter", "SER_REF", "industry_code", "industry_name", "filled jobs", "filled jobs revised",
            "filled jobs diff", "filled jobs % diff", "total_earnings", "total earnings revised", "earnings diff",
            "earnings % diff"
        };
        int rowIndex = 1;
        WriteValue(workSheet, rowIndex++, cellValues); // write header values
        foreach (var surveyData in dataList)
        {
            var rowCellValues = new[]
            {
                $"{surveyData.Quarter}", $"{surveyData.SerRef}", $"{surveyData.IndustryCode}",
                $"{surveyData.IndustryName}", $"{surveyData.Filledjobs}", $"{surveyData.Filledjobsrevised}",
                $"{surveyData.FilledJobsDiff}", $"{surveyData.FilledJobsPercentDiff}", $"{surveyData.TotalEarnings}",
                $"{surveyData.Totalearningsrevised}", $"{surveyData.EarningsDiff}", $"{surveyData.EarningsPercentDiff}"
            };
            WriteValue(workSheet, rowIndex++, rowCellValues);
        }

        workBook.SaveAsCsv($"{fileName}.csv");
    }

    private void WriteValue(WorkSheet workSheet, int rowIndex, string[] cellValues)
    {
        var colindex = 1;
        foreach (var value in cellValues)
        {
            var colLetter = ColumnIndexToColumnLetter(colindex++);
            var rangeAddress = $"{colLetter}{rowIndex}:{colLetter}{rowIndex}";
            workSheet[rangeAddress].Value = value;
        }
    }

    private static string ColumnIndexToColumnLetter(int colIndex)
    {
        int div = colIndex;
        string colLetter = String.Empty;
        int mod = 0;

        while (div > 0)
        {
            mod = (div - 1) % 26;
            colLetter = (char)(65 + mod) + colLetter;
            div = (int)((div - mod) / 26);
        }

        return colLetter;
    }
}