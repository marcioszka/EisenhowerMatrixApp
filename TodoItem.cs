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

        public TodoItem(string title, DateTime deadline)
        {
            _title = title;
            _deadline = deadline;
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

        public static void ShowColoredTodoItem(TodoItem item)
        {
            DateTime deadline = item._deadline;
            TimeSpan timeLeft = deadline - DateTime.Today;

            if (timeLeft.TotalDays > 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (timeLeft.TotalDays > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //Console.ResetColor();
        }

        public override string ToString()
        {
            return $"[{GetSymbolForStatus()}] {ChangeDeadlineFormat()} {_title}";
        }
    }

}