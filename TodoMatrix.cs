using System;

namespace EisenhowerMatrixApp
{
    public class TodoMatrix
    {
        private Dictionary<string, TodoQuarter> TodoQuarters;

        public TodoMatrix()
        {
            TodoQuarters = new Dictionary<string, TodoQuarter>();
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
            // Adds new item to dictionary todoQuarters using adequate key.
            // You should use method AddItem from TodoQuarter class.
        }

        public void AddItemsFromFile(string filename)
        {
            //Reads data from fileName.csv file and appends TodoItem objects to attributes todoItems in the properly TodoQuarter objects.
            //Every item is written in a separate line in format:
            //title|day-month|is_important
        }

        public void SaveItemsToFile(string filenmename)
        {
            //Writes all details about TODO items to fileName.csv file
            //Every item is written in a separate line the following format:
            //title | day - month | is_important
        }

        public void ArchiveItems()
        {
            //Removes all TodoItem objects with a parameter isDone set to true
            //from list todoItems in every element of dictionary todoQuarters
        }

        public override string ToString()
        {
            //Returns a todoQuarters list (an Eisenhower todoMatrix) formatted to string.
            return "";
        }
    }

}