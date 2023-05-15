using System;
using System.ComponentModel;

namespace EisenhowerMatrixApp.src.EisenhowerMartixApp.Model
{
    public class TodoItem
    {
        public int Id { get; set; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{GetSymbolForStatus()}] {ChangeDeadlineFormat()} {_title}";
        }
    }

}