using System;
using System.ComponentModel;

namespace EisenhowerMatrixApp
{
    public class TodoItem
    {
        private string Title;

        private DateTime Deadline;

        private bool IsDone;// = false;
        [DefaultValue(false)]

        public TodoItem(string title, DateTime deadline)
        {
            Title = title;
            Deadline = deadline;
        }

        public string GetTitle() { return Title; }

        public DateTime GetDeadline() { return Deadline; }

        public string ChangeDeadlineFormat() { return Deadline.ToString("d-M"); }

        public bool GetStatus() { return IsDone; }

        private string GetSymbolForStatus()
        {
            switch (IsDone)
            {
                case true:
                    return "x";
                case false: 
                    return " ";
            }
        }

        public void Mark()
        {
            IsDone = true;
        }

        public void Unmark()
        {
            IsDone = false;
        }

        public override string ToString()
        {
            return $"[{GetSymbolForStatus()}] {ChangeDeadlineFormat()} submit assignment";
        }
    }

}