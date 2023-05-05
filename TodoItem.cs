using System;
using System.ComponentModel;

namespace EisenhowerMatrixApp
{
    public class TodoItem
    {
        private string _title;

        private DateTime _deadline;

        private bool _isDone;
        [DefaultValue(false)]

        public TodoItem(string title, DateTime deadline, bool isDone= false)
        {
            _title = title;
            _deadline = deadline;
            _isDone = isDone;
        }

        public string GetTitle() { return _title; }

        public DateTime GetDeadline() { return _deadline; }

        private string ChangeDeadlineFormat() { return _deadline.ToString("d-M"); }

        public bool GetStatus() { return _isDone; }

        private string GetSymbolForStatus()
        {
            switch (_isDone)
            {
                case true:
                    return "x";
                case false: 
                    return " ";
            }
        }

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
    }

}