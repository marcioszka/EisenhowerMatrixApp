using System;

namespace EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            var task1 = new TodoItem("nakarmic rybki", DateTime.Now);
            task1.Mark();
            var task2 = new TodoItem("podlac kwiatki", DateTime.Now.AddDays(1));
            var task3 = new TodoItem("zrobic pranie", DateTime.Now.AddDays(-1));
            Console.WriteLine(task1.ToString());
            Console.WriteLine(task2.ToString());
            Console.WriteLine(task3.ToString());
            //TodoQuarter todoQuarter = new TodoQuarter();
            //todoQuarter.AddItem("nakarmic rybki", DateTime.Now);
            //todoQuarter.AddItem("podlac kwiatki", DateTime.Now.AddDays(1));
            //todoQuarter.AddItem("odkurzyc salon", DateTime.Now.AddDays(-3));
            //var taskList = todoQuarter.GetItems();
            //foreach (TodoItem item in taskList)
            //{ Console.WriteLine(item.ToString()); }
            //string list = taskList.ToString();
            //Console.WriteLine(list);
        }
    }
}
