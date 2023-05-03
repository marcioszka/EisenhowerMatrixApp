using System;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            
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
            

            Console.WriteLine("\nPo archiwizacji:");
            Console.WriteLine(importantUrgent.ToString());
            

            var date = StringHelper.SetDeadlineYear("26", "1");
            Console.WriteLine(date);
            var datum = DateTime.Parse(date);
            Console.WriteLine(datum.ToString("d-M"));
            

            TodoMatrix organiser = new TodoMatrix();
            organiser.AddItem("zdac hindi", DateTime.Now.AddDays(2));
            organiser.AddItem("referat z sanskrytu", DateTime.Now.AddDays(3), true);
            organiser.AddItem("ugotowac kluski", DateTime.Now.AddDays(15), true);
            organiser.AddItem("obrac ziemniaki", DateTime.Now.AddDays(9));
            organiser.AddItem("odrobki z literatury", DateTime.Now.AddDays(3));
            organiser.AddItem("kupic nowa sukienke", DateTime.Now.AddDays(1), true);
            organiser.AddItem("egzamin na hulajnoge", DateTime.Now.AddDays(7), true);
            Console.WriteLine(organiser.ToString());
        }
    }
}
