using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class Display
    {
        private static string[] MainMenu = {"Choose following options:", "[A] Add new task", "[S] See your planner", "[C] Change status of a task", "[D] Delete task from planner", "[R] Read planner from file", "[X] Exit application" };

        private static string[] TaskMenu = { "[A] Add another task", "[S] See your planner", "[M] Back to Main menu" };

        private static string[] MatrixKeys = { "IU", "IN", "NU", "NN" };

        private const int QUARTER_NUMBER = 4;

        private const string important = " IMPORTANT ";

        private const string notImportant = " NOT IMPORTANT ";

        private static Dictionary<string, string> UserCommunication = new Dictionary<string, string> {
            { "welcome", "Welcome to Eisenhower Matrix App, your task planner!\n"},
            { "title", "Write the title of your upcoming task:" }, 
            { "day", "\nSpecify the last day of your assignement:"}, 
            { "month", "\nSpecify the month of the assignement:" },
            { "importance", "Is this task important? (y/n)"},
            { "quarter", "Which quarter would you like to edit?\n[IU] important & urgent,\n[IN] important & not urgent,\n[NU] not important & urgent,\n[NN] not important & not urgent." },
            { "index", "\nSpecify ordinal number of the task." },
            { "wrongInput", "\nSuch an option there is none. Again type you must!" },
            { "isAdded", "You've added your task successfully.\n"},
            { "isRemoved", "You've removed your task successfully.\n"},
            { "noItem", "There is no such task in your planner.\n"},
            { "status", "Status have been succesfully changed.\n"},
            { "plannerSaved", "\nToo much to do? Don't worry, we'll keep your planner saved." },
            { "exit", "\nPress any key to exit." } };

        public static void PrintMenu()
        {
            foreach (string option in MainMenu)
            {
                Console.WriteLine(option);
            }
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(UserCommunication[message]);
        }

        public static void PrintPlanner(TodoMatrix planner)
        {
            Console.Clear();
            Console.WriteLine("\t\tU R G E N T\t\t|\t\tN O T  U R G E N T\t\t");
            for (int i = 0; i < QUARTER_NUMBER; i = i + 2)
            {
                var Uquarter = planner.GetQuarter(MatrixKeys[i]);
                int Ucount = Uquarter.GetItems().Count;
                var Nquarter = planner.GetQuarter(MatrixKeys[i + 1]);
                int Ncount = Nquarter.GetItems().Count;
                string importantOrNot = "";

                if(i == 0) { importantOrNot = important; }
                else { importantOrNot = notImportant; }
                Console.WriteLine("------------------------------------------------------------------------------------|");
                for (int j=0; j< importantOrNot.Length; j++)
                {
                    string Utask = "";
                    string Ntask = "";
                    if (j<Ucount) { Utask = Uquarter.GetItem(j).ToString();}
                    if (j < Ncount) { Ntask = Nquarter.GetItem(j).ToString(); }

                    Console.WriteLine($" {importantOrNot[j]}  |\t{Utask}\t\t\t\t|\t{Ntask}   \t\t\t\t|\n");
                }
            }
            Console.WriteLine("------------------------------------------------------------------------------------|");
            //Console.WriteLine(planner.ToString()); 
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

        public static void ShowColoredTodoItem(TodoItem item, string task)
        {
            DateTime deadline = item.GetDeadline();
            var timeLeft = (deadline - DateTime.Now).TotalDays;
            if (!item.IsDone() && timeLeft > 3)
            {
                PrintGreen(task);
            }
            else if (!item.IsDone() && timeLeft > 0)
            {
                PrintYellow(task);
            }
            else if (!item.IsDone() && timeLeft==0)
            {
                PrintRed(task);
            }
        }

        public static void PrintGreen(string task)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(task);
            Console.ResetColor();
        }

        public static void PrintYellow(string task)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(task);
            Console.ResetColor();
        }

        public static void PrintRed(string task)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(task);
            Console.ResetColor();
        }
    }
}
