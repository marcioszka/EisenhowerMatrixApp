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
                //if item.IsDone == false -> remove item from TodoItems
            }
        }

        public List<TodoItem> GetItems()
        {
            return TodoItems;
        }

        public string ToString()
        {
            //return formatted list of TodoItems: [ ] day-month task / [x] day-month submit assignment
            return "";
        }
    }

}