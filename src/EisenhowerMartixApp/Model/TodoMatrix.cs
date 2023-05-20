using System;

namespace EisenhowerMatrixApp.src.EisenhowerMartixApp.Model
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

        public void AddItem(string title, DateTime deadline, bool isImportant = false, bool isDone = false)
        {
            var isUrgent = IsItemUrgent(deadline);
            if (isImportant && isUrgent) 
            {
                _todoQuarters["IU"].AddItem(title, deadline, isDone);
            }
            else if (isImportant && !isUrgent) 
            {
                _todoQuarters["IN"].AddItem(title, deadline, isDone);
            }
            else if (!isImportant && isUrgent)
            {
                _todoQuarters["NU"].AddItem(title, deadline, isDone);
            }
            else
            {
                _todoQuarters["NN"].AddItem(title, deadline, isDone);
            }
        }

        private bool IsItemUrgent(DateTime deadline) 
        {
            int timeSpan = 72;
            return (deadline - DateTime.Now).TotalHours <= timeSpan; 
        }

        public void AddItemsFromFile(string filename)
        {
            string[] tasks = File.ReadAllLines(filename);
            foreach (string task in tasks)
            {
                string[] taskDetails = task.Split('|');
                //TodoQuarters[key].AddItem(taskDetails[0], taskDetails[1]);  //TODO: taskDetails[1] - parse to DateTime
            }

        }

        public void SaveItemsToFile(string filename)
        {
            
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
                matrix += $"{quarter.Key}\n{quarter.Value.ToString()}\n\n";

            }
            return matrix;
        }
    }

}