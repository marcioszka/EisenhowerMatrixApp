using System;

namespace EisenhowerMatrixApp
{
    public class TodoMatrix
    {
        private readonly Dictionary<string, TodoQuarter> _todoQuarters;

        public TodoMatrix() // TODO: is it proper way to declare this matrix?
        {
            _todoQuarters = new Dictionary<string, TodoQuarter>()
            {
                { "IU", new TodoQuarter() },
                { "IN", new TodoQuarter() },
                { "NU", new TodoQuarter() },
                { "NN", new TodoQuarter() }
            };
        }

        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return _todoQuarters;
        }

        public TodoQuarter GetQuarter(string status)
        {
            return _todoQuarters[status];
        }

        public void AddItem(string title, DateTime deadline, bool IsImportant = false)
        {
            string key = "UI";  // TODO: przekazac key od usera
            _todoQuarters[key].AddItem(title, deadline);
        }

        public void AddItemsFromFile(string filename)
        {
            string[] tasks = File.ReadAllLines(filename);
            foreach (string task in tasks)
            {
                string[] taskDetails = task.Split('|');
                //TodoQuarters[key].AddItem(taskDetails[0], taskDetails[1]);  //TODO: taskDetails[1] - parse to DateTime
            }
            //If the last element of line is an empty string,
            //*isImportant* is equal to false - assigned to a not important TODO quarter.
            //Otherwise item should be assign to an important TODO quarter.
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
            foreach(var quarter in _todoQuarters)
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