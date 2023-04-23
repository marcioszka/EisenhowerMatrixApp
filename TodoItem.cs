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

        public void Mark()
        {
            IsDone = true;
        }

        public void Unmark()
        {
            IsDone = false;
        }

        public string ToString(bool IsDone)
        {
            //deadline to day-month, IsDone: true -> x, false -> ''
            return $"[{IsDone}] {GetDeadline().ToString("d-M")} submit assignment";
        }
    }

}