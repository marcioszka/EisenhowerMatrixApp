using System;

namespace EisenhowerMatrixApp
{
    public class TodoMatrix
    {
        private Dictionary<string, TodoQuarter> TodoQuarters;

        public TodoMatrix() // TODO: is it proper way to declare this matrix?
        {
            TodoQuarters = new Dictionary<string, TodoQuarter>()
            {
                { "IU", new TodoQuarter() },
                { "IN", new TodoQuarter() },
                { "NU", new TodoQuarter() },
                { "NN", new TodoQuarter() }
            };
        }

        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return TodoQuarters;
        }

        public TodoQuarter GetQuarter(string status)
        {
            return TodoQuarters[status];
        }

        public void AddItem(string title, DateTime deadline, bool IsImportant = false)
        {
            string key = "UI";  // TODO: przekazac key od usera
            TodoQuarters[key].AddItem(title, deadline);
        }

        public void AddItemsFromFile(string filename)
        {
            //Reads data from fileName.csv file and appends TodoItem objects to attributes todoItems in the properly TodoQuarter objects.
            //Every item is written in a separate line in format:
            //title|day-month|is_important
        }

        public void SaveItemsToFile(string filename)
        {
            //Writes all details about TODO items to fileName.csv file
            //Every item is written in a separate line the following format:
            //title | day - month | is_important
        }

        public void ArchiveItems()
        {
            foreach(var quarter in TodoQuarters)
            {
                quarter.Value.ArchiveItems();
            }
        }

        public override string ToString()
        {
            //Returns a todoQuarters list (an Eisenhower todoMatrix) formatted to string.
            return "";
        }
    }

}