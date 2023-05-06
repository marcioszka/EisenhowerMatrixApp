using System;

namespace EisenhowerMatrixApp
{
    public class TodoMatrix
    {
        private readonly Dictionary<string, TodoQuarter> _todoQuarters;

        public TodoMatrix()
        {
            _todoQuarters = new Dictionary<string, TodoQuarter>()
            {
                { "IU", new TodoQuarter() },
                { "IN", new TodoQuarter() },
                { "NU", new TodoQuarter() },
                { "NN", new TodoQuarter() }
            };
        }

        public Dictionary<string, TodoQuarter> GetQuarters() => _todoQuarters;

        public TodoQuarter GetQuarter(string status) => _todoQuarters[status];

        public void AddItem(string title, DateTime deadline, bool isImportant = false) //TODO: f. wybierajaca cwiartke pod wzgledem tych dwóch argumentów
        {
            var isUrgent = IsItemUrgent(deadline);
            if (isImportant && isUrgent) 
            {
                _todoQuarters["IU"].AddItem(title, deadline);
            }
            else if (isImportant && !isUrgent) 
            {
                _todoQuarters["IN"].AddItem(title, deadline);
            }
            else if (!isImportant && isUrgent)
            {
                _todoQuarters["NU"].AddItem(title, deadline);
            }
            else
            {
                _todoQuarters["NN"].AddItem(title, deadline);
            }
        }

        private bool IsItemUrgent(DateTime deadline) 
        {
            int timeSpan = 3;
            return (deadline - DateTime.Now).TotalDays <= timeSpan; 
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
            string matrix = "";
            foreach (var quarter in _todoQuarters)
            {
                matrix += $"{quarter.Key}\n{quarter.Value.ToString()}";
            }
            return matrix;
        }
    }

}