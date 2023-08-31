// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.Json;
using CsvGenerators;
using CsvGenerators.Generators;

Console.WriteLine("\n\n--------------------Testing Different CSv Generator--------------------\n\n");

var data = JsonSerializer.Deserialize<SurveyData[]>(File.ReadAllText("data.json"));

Console.WriteLine($"No of Records used for this test - {data.Length}\n\n");

Console.WriteLine($"------------Writing CSv Using StringBuilder------------");
var stringBuilder = new StringBuilderCsvGenerator();
var sw = Stopwatch.StartNew();
stringBuilder.Generate(data,"stringBuilder");
sw.Stop();
Console.WriteLine($"Time taken to write using StringBuilderCsvGenerator-{sw.ElapsedMilliseconds}\n\n");

Console.WriteLine($"------------Writing CSv Using CsvHelper------------");
var csvHelper = new CsvHelperCsvGenerator();
sw.Restart();
csvHelper.Generate(data,"CsvCsvGenerator");
sw.Stop();
Console.WriteLine($"Time taken to write using CsvHelperCsvGenerator -{sw.ElapsedMilliseconds}\n\n");

Console.WriteLine($"------------Writing CSv Using IronXl------------");
var ironExcel = new IronXLGenerator();
sw.Restart();
ironExcel.Generate(data,"IronXlCsvGenerator");
sw.Stop();
Console.WriteLine($"Time taken to write using CsvHelperCsvGenerator -{sw.ElapsedMilliseconds}\n\n");