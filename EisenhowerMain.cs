using System;

namespace EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            Display.PrintMenu();

            var task1 = new TodoItem("rybki", DateTime.Now);
            Console.WriteLine(task1.GetDeadline());

        }
    }
}
