using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class Display
    {
        private static string[] MainMenu = { "Welcome to Eisenhower Matrix App, your task planner!\n", "Choose following options:", "[A] Add new task", "[S] See your planner", "[C] Choose task to edit", "[D] Delete task from planner", "[X] Exit application" };

        private static string[] TaskMenu = { "[A] Add another task", "[S] See your planner", "[M] Back to Main menu" };

        private static Dictionary<string, string> UserCommunication = new Dictionary<string, string> { { "title", "Write title of your upcoming task:" }, 
            { "day", "Specify the last day of your assignement:"}, 
            { "month", "Specify the month of the assignement:" },
            { "importance", "Is this task important? (y/n)"},
            { "quarter", "Which quarter would you like to edit?\n[IU] important & urgent,\n[IN] important & not urgent,\n[NU] not important & urgent,\n[NN] not important & not urgent." },
            { "index", "Specify ordinal number of task to remove from your list." } };

        public static void PrintMenu()
        {
            foreach (string option in MainMenu)
            {
                Console.WriteLine(option);
            }
        }

        public static void PrintMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(UserCommunication[message]);
        }

        public static void PrintPlanner(TodoMatrix planner)
        { 
            Console.WriteLine(planner.ToString()); 
        }

        public static void PrintTaskMenu(string title)
        {
            Console.Clear();
            Console.WriteLine($"You've added task '{title}' successfully.\n");
            foreach (string option in TaskMenu)
            {
                Console.WriteLine(option);
            }
        }
    }
}
