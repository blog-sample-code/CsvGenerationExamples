namespace CsvGenerators.Generators;

public interface ICsvGenerator
{
    void Generate(SurveyData[] dataList, string fileName);
}