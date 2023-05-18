using System;
using System.ComponentModel;

namespace EisenhowerMatrixApp
{
    public class TodoItem
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

        public void ShowColoredTodoItem()
        {
            var timeLeft = (_deadline - DateTime.Now).TotalDays;
            if (timeLeft > 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (timeLeft > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ResetColor();
        }
    }

}