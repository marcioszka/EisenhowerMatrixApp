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


        public void AddItem(string title, DateTime deadline, bool isDone = false) => _todoItems.Add(new TodoItem(title, deadline, isDone));

        public void RemoveItem(int index) => _todoItems.RemoveAt(index);

        public void ArchiveItems() => _todoItems.RemoveAll(item => item.IsDone());

        public override string ToString()
        {
            string taskList = "";
            int index = 1;
            foreach(TodoItem item in _todoItems) 
            {
                taskList += $"{index}. {item.ToString()}\n";
                index++;
            }
            return taskList;
        }

        public override bool Equals(object quarter)
        {
            if (quarter == null) return false;
            if (!(quarter is TodoQuarter)) return false;
            if (!(_todoItems.Count == ((TodoQuarter)quarter).GetItems().Count)) return false;
            for (int i=0; i< _todoItems.Count; i++) 
            {
                if(!_todoItems[i].Equals(((TodoQuarter)quarter).GetItem(i))) return false;
             //   bool condition = (_todoItems[i].GetTitle() == ((TodoQuarter)quarter).GetItem(i).GetTitle() && _todoItems[i].GetDeadline() == ((TodoQuarter)quarter).GetItem(i).GetDeadline() && _todoItems[i].IsDone() == ((TodoQuarter)quarter).GetItem(i).IsDone());
             //   if (!condition) return false;
            }
            return true;
        }
    }

}