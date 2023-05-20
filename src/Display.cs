using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            foreach (string option in MainMenu) { Console.WriteLine(option); }
        }

        public static void PrintMessage(string message) => Console.WriteLine(UserCommunication[message]);
       
        public static void PrintPlanner(TodoMatrix planner)
        {
            Console.Clear();
            Console.Clear();
            //Console.WriteLine("\x1b[3J");
            Console.WriteLine("   |                  URGENT                 |               NOT  URGENT               | ");
            Console.WriteLine("---+-----------------------------------------+-----------------------------------------+-");
            for (int i = 0; i < QUARTER_NUMBER; i=i+2)
            {
                var urgentQuarter = planner.GetQuarter(MatrixKeys[i]);
                int urgentItemsCount = urgentQuarter.GetItems().Count;
                var notUrgentQuarter = planner.GetQuarter(MatrixKeys[i + 1]);
                int notUrgentItemsCount = notUrgentQuarter.GetItems().Count;
                string importantOrNot = "";
                int cellWidth = 41;

                if (i == 0) { importantOrNot = "   IMPORTANT   "; }
                else { importantOrNot = " NOT IMPORTANT "; }
                if (importantOrNot == " NOT IMPORTANT ") { Console.WriteLine("---+-----------------------------------------+-----------------------------------------+-"); }
                for (int j = 0; j < importantOrNot.Length; j++)
                {                    
                    if (j < urgentItemsCount)
                    {
                        var urgentTask = urgentQuarter.GetItem(j);

                        Console.Write($" {importantOrNot[j]} |");
                        ShowColoredTodoItem(urgentTask);
                        Console.Write($"{StringHelper.GetEmptySpaceToDisplay(urgentTask, cellWidth)}|");
                    }
                    else { Console.Write($" {importantOrNot[j]} |                                         |"); }
                    if (j < notUrgentItemsCount)
                    {
                        var notUrgentTask = notUrgentQuarter.GetItem(j);
                        ShowColoredTodoItem(notUrgentTask);
                        Console.Write($"{StringHelper.GetEmptySpaceToDisplay(notUrgentTask, cellWidth)}|");
                    }
                    else
                    {
                        Console.Write("                                         |   ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("---+-----------------------------------------+-----------------------------------------+-");
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

        public static void ShowColoredTodoItem(TodoItem item)
        {
            string task = item.ToString();
            DateTime deadline = item.GetDeadline();
            var timeLeft = (deadline - DateTime.Now).TotalHours;
            if (!item.IsDone() && timeLeft >= 72) { PrintGreen(); }
            else if (!item.IsDone() && timeLeft >= 24 && !item.IsDone() && timeLeft < 72) { PrintYellow(); }
            else if (!item.IsDone() && timeLeft < 24) { PrintRed(); }
            Console.Write(task);
            PrintWhite();
        }


        public static void PrintGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void PrintYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void PrintRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void PrintWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
