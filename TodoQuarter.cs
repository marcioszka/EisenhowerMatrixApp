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

        public void AddItem(string title, DateTime deadline) 
        {
            TodoItems.Append(new TodoItem(title, deadline));
        }

        public void RemoveItem(int index) 
        { 
            TodoItems.RemoveAt(index);
        }

        public void ArchiveItems() 
        {
            foreach (TodoItem item in TodoItems)
            {
                if (item.GetStatus() == false) { TodoItems.Remove(item); }
            }
        }

        public List<TodoItem> GetItems()
        {
            return TodoItems;
        }

        public override string ToString() // TODO: poprawic
        {
            //return formatted list of TodoItems: [ ] day-month task / [x] day-month submit assignment
            string taskList = "";
            List<string> list = new List<string>;
            for (int index = 1;  index <= TodoItems.Count; index++)
            {
                list.Append($"{index}. {TodoItems[index - 1].ToString()}");
                taskList += $"{index}. {TodoItems[index - 1].ToString()}";
            }
            return taskList;
        }
    }

}