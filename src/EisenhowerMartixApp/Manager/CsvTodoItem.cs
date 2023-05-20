using CsvHelper.Configuration.Attributes;
using EisenhowerMatrixApp.src.EisenhowerMartixApp.Model;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp.Manager;

public class CsvTodoItem
{
    [Name("id")]
    public int Id { get; set; }
    [Name("title")]
    public string Title { get; set; }
    [Name("deadlineYear")]
    public int DeadlineYear { get; set; }
    [Name("deadlineMonth")]
    public int DeadlineMonth { get; set; }
    [Name("deadlineDay")]
    public int DeadlineDay { get; set; }
    [Name("isImportant")]
    public bool IsImportant { get; set; }
    [Name("isDone")]
    public bool IsDone { get; set; }

    public CsvTodoItem(TodoItem source, bool important)
    {
        Id = source.Id;
        Title = source.GetTitle();
        IsDone = source.IsDone();
        DeadlineYear = source.GetDeadline().Year;
        DeadlineMonth = source.GetDeadline().Month;
        DeadlineDay = source.GetDeadline().Day;
        IsImportant = important;
    }
    public CsvTodoItem(int id, string title, int deadlineYear, int deadlineMonth, int deadlineDay, bool isImportant, bool isDone)
    {
        Id = id;
        Title = title;
        IsDone = isDone;
        DeadlineYear = deadlineYear;
        DeadlineMonth = deadlineMonth;
        DeadlineDay = deadlineDay;
        IsImportant = isImportant;
    }

    public static List<CsvTodoItem> PrepareListForCsvWriting(TodoMatrix matrix)
    {
        List<CsvTodoItem> csvPreparedTodos = new List<CsvTodoItem>();
        foreach (var quarter in matrix.GetQuarters())
        {
            bool important = quarter.Key.ToLower()[0] == 'i';
            foreach (TodoItem item in quarter.Value.GetItems())
            {
                csvPreparedTodos.Add(new CsvTodoItem(item, important));
            }
        }
        return csvPreparedTodos;
    }

    public static TodoMatrix MakeMatrixFromCsvTodoItems(List<CsvTodoItem> csvTodoItems) // TODO:? This function has to be changed depending on the decision of how to treat the CSV backup 
    {
        TodoMatrix matrix = new TodoMatrix();
        foreach (CsvTodoItem csvTodoItem in csvTodoItems)
        {
            matrix.AddItem(csvTodoItem.Title, new DateTime(csvTodoItem.DeadlineYear, csvTodoItem.DeadlineMonth, csvTodoItem.DeadlineDay), csvTodoItem.IsImportant, csvTodoItem.IsDone);
        }
        return matrix;
    }
}