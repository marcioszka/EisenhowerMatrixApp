using System;
using System.Collections.Generic;
using System.Text;

namespace EisenhowerMatrixApp
{

    public class TodoQuarter
    {
        private List<TodoItem> TodoItems;

        public TodoQuarter() 
        {
            TodoItems = new List<TodoItem>();
        }

        public List<TodoItem> GetItems()
        {
            return TodoItems;
        }

        public void AddItem(string title, DateTime deadline) 
        {
            TodoItems.Add(new TodoItem(title, deadline));
        }

        public void RemoveItem(int index) 
        { 
            TodoItems.RemoveAt(index);
        }

        public void ArchiveItems()
        {
            TodoItems.RemoveAll(item => !item.GetStatus());
        }

        public override string ToString()
        {
            string taskList = "";
            int index = 1;
            foreach(TodoItem item in TodoItems) 
            { 
                taskList += $"{index}. {item.ToString()}\n";
                index++;
            }
            return taskList;
        }
    }

}