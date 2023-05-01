using System;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            //var task1 = new TodoItem("nakarmic rybki", DateTime.Now);
            //task1.Mark();
            //var task2 = new TodoItem("podlac kwiatki", DateTime.Now.AddDays(1));
            //var task3 = new TodoItem("zrobic pranie", DateTime.Now.AddDays(-1));
            //Console.WriteLine(task1.ToString());
            //Console.WriteLine(task2.ToString());
            //Console.WriteLine(task3.ToString());
            //Console.WriteLine();
            //Console.WriteLine();

            TodoQuarter importantUrgent = new TodoQuarter();
            importantUrgent.AddItem("nakarmic psa", DateTime.Now);
            importantUrgent.AddItem("odkurzyc dom", DateTime.Now.AddDays(1));
            importantUrgent.AddItem("wyprac firanki", DateTime.Now.AddDays(-5));
            importantUrgent.AddItem("zamiesc podworze", DateTime.Now.AddDays(10));
            Console.WriteLine(importantUrgent.ToString());
            var list = importantUrgent.GetItems();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetTitle()} {item.GetStatus()}");
            }
            importantUrgent.ArchiveItems();
            //importantUrgent.AddItem("wyrzucic smieci", DateTime.Now.AddMonths(2));
            //var tasks = importantUrgent.GetItems();

            Console.WriteLine("\nPo archiwizacji:");
            Console.WriteLine(importantUrgent.ToString());
            //foreach (var task in tasks)
            //{  }
            //
            //todoQuarter.AddItem("odkurzyc salon", DateTime.Now.AddDays(-3));
            //var taskList = todoQuarter.GetItems();

            //string list = taskList.ToString();
            //Console.WriteLine(list);
        }
    }
}
