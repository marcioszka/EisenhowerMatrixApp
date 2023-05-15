using System.Globalization;
using CsvHelper;
using EisenhowerMatrixApp.src.EisenhowerMartixApp.Model;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp.Manager;

static class CsvHandler
{
    private const string CsvStoreFolder = "savedTodos";
    private const string DefaultFileName = "defaultMatrix.csv";
    public static void SaveMatrixToCsv(TodoMatrix matrix, string filename = DefaultFileName)
    {
        List<CsvTodoItem> csvTodoItems = CsvTodoItem.PrepareListForCsvWriting(matrix);
        if (!Directory.Exists(CsvStoreFolder))
        {
            Directory.CreateDirectory(CsvStoreFolder);
        }
        using var writer = new StreamWriter(File.Create(Path.Combine(CsvStoreFolder, filename)));
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(csvTodoItems);
    }

    public static TodoMatrix ReadMatrixFromCsv(string filename = DefaultFileName)
    {
        using var reader = new StreamReader(Path.Combine(CsvStoreFolder, filename));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<CsvTodoItem>();
        return CsvTodoItem.MakeMatrixFromCsvTodoItems(records.ToList());
    }
}