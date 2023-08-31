// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);

using System.Text.Json.Serialization;

namespace CsvGenerators;

public class SurveyData
{
    [JsonPropertyName("quarter")] public double Quarter { get; set; }

    [JsonPropertyName("SER_REF")] public string SerRef { get; set; } = string.Empty;

    [JsonPropertyName("industry_code")] public string IndustryCode { get; set; } = string.Empty;

    [JsonPropertyName("industry_name")] public string IndustryName { get; set; } = string.Empty;

    [JsonPropertyName("filled jobs")] public int Filledjobs { get; set; }

    [JsonPropertyName("filled jobs revised")]
    public int Filledjobsrevised { get; set; }

    [JsonPropertyName("filled jobs diff")] public int FilledJobsDiff { get; set; }

    [JsonPropertyName("filled jobs % diff")]
    public double FilledJobsPercentDiff { get; set; }

    [JsonPropertyName("total_earnings")] public int TotalEarnings { get; set; }

    [JsonPropertyName("total earnings revised")]
    public int Totalearningsrevised { get; set; }

    [JsonPropertyName("earnings diff")] public int EarningsDiff { get; set; }

    [JsonPropertyName("earnings % diff")] public double EarningsPercentDiff { get; set; }
}