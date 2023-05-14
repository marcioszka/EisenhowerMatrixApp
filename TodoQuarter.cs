using System;
using System.Collections.Generic;
using System.Text;

namespace EisenhowerMatrixApp
{

    public class TodoQuarter
    {
        public List<TodoItem> _todoItems;

        public TodoQuarter() 
        {
            _todoItems = new List<TodoItem>();
        }

        public TodoQuarter(List<TodoItem> todoItems)
        {
            _todoItems = todoItems;
        }

        public List<TodoItem> GetItems() => _todoItems;
       

        public TodoItem GetItem(int index) => _todoItems[index];


        //public void AddItem(string title, DateTime deadline) => _todoItems.Add(new TodoItem(title, deadline));

        public void AddItem(string title, DateTime deadline, bool isDone = false) => _todoItems.Add(new TodoItem(title, deadline, isDone));

        public void RemoveItem(int index) => _todoItems.RemoveAt(index);

        public void ArchiveItems() => _todoItems.RemoveAll(item => item.IsDone());

        public override string ToString()
        {
            string taskList = "";
            int index = 1;
            foreach(TodoItem item in _todoItems) 
            {
                //Display.ShowColoredTodoItem(item);
                taskList += $"{index}. {item.ToString()}\n";
                index++;
            }
            //Console.ResetColor();
            return taskList;
        }
    }

}