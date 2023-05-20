using System;
using System.ComponentModel;

namespace EisenhowerMatrixApp
{
    public class TodoItem : IEquatable<TodoItem>
    {
        private string _title;

        private DateTime _deadline;

        private bool _isDone;

        public TodoItem(string title, DateTime deadline, bool isDone = false)
        {
            _title = title;
            _deadline = deadline;
            _isDone = isDone;
        }

        public string GetTitle() => _title;

        public DateTime GetDeadline() => _deadline; 

        private string ChangeDeadlineFormat() => _deadline.ToString("d-M");

        public bool IsDone() => _isDone;

        private string GetSymbolForStatus() => _isDone ? "x" : " ";

        public void Mark()
        {
            _isDone = true;
        }

        public void Unmark()
        {
            _isDone = false;
        }

        public override string ToString()
        {
            return $"[{GetSymbolForStatus()}] {ChangeDeadlineFormat()} {_title}";
        }

        //public bool Equals(TodoItem? other)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Equals(TodoItem? comparedItem)
        {
            //if (comparedItem == null) return false;
            //if (!(comparedItem is TodoItem)) return false;
            return (this._title == ((TodoItem)comparedItem)._title) && (this._deadline == ((TodoItem)comparedItem)._deadline) && (this._isDone == ((TodoItem)comparedItem)._isDone);
        }
    }

}