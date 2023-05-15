﻿using DataTablePrettyPrinter;
using System.Data;
using EisenhowerMatrixApp.src.EisenhowerMartixApp.Model;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp.View
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
            DataTable eisenhowerMatrix = new DataTable();
            eisenhowerMatrix.Columns.Add("quarter", typeof(string)).SetDataAlignment(TextAlignment.Center);
            eisenhowerMatrix.Columns.Add("URGENT", typeof(string)).SetDataAlignment(TextAlignment.Left);
            eisenhowerMatrix.Columns.Add("NOT URGENT", typeof(string)).SetDataAlignment(TextAlignment.Left);
            eisenhowerMatrix.Columns[0].SetWidth(3);
            eisenhowerMatrix.Columns[1].SetWidth(40);
            eisenhowerMatrix.Columns[2].SetWidth(40);
            eisenhowerMatrix.SetShowTableName(false);
            eisenhowerMatrix.Columns[0].SetShowColumnName(false);

            Console.Clear();
            for (int i = 0; i < QUARTER_NUMBER; i = i + 2)
            {
                var Uquarter = planner.GetQuarter(MatrixKeys[i]);
                int Ucount = Uquarter.GetItems().Count;
                var Nquarter = planner.GetQuarter(MatrixKeys[i + 1]);
                int Ncount = Nquarter.GetItems().Count;
                string importantOrNot = "";

                if (i == 0) { importantOrNot = " IMPORTANT "; }
                else { importantOrNot = " NOT IMPORTANT "; }
                if(importantOrNot == " NOT IMPORTANT ") { eisenhowerMatrix.Rows.Add("-", "--------------------------------------", "--------------------------------------"); }
                for (int j = 0; j < importantOrNot.Length; j++)
                {
                    string Utask = "";
                    string Ntask = "";
                    if (j < Ucount) 
                    {
                        Utask = Uquarter.GetItem(j).ToString();
                    }
                    if (j < Ncount) 
                    {
                        Ntask = Nquarter.GetItem(j).ToString();
                    }
                    eisenhowerMatrix.Rows.Add(importantOrNot[j], Utask, Ntask);
                }
            }
            Console.WriteLine(eisenhowerMatrix.ToPrettyPrintedString());
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

        public static string ShowColoredTodoItem(TodoItem item)
        {
            string task = item.ToString();
            DateTime deadline = item.GetDeadline();
            var timeLeft = (deadline - DateTime.Now).TotalDays;
            if (!item.IsDone() && timeLeft > 3) { return PrintGreen(task); }
            else if (!item.IsDone() && timeLeft > 0) { return PrintYellow(task); }
            else if (!item.IsDone() && timeLeft==0) { return PrintRed(task); }
            else { return PrintWhite(task); }
        }

        public static string PrintGreen(string task)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return task;
        }

        public static string PrintYellow(string task)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return task;
        }

        public static string PrintRed(string task)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return task;
        }

        public static string PrintWhite(string task)
        {
            Console.ForegroundColor = ConsoleColor.White;
            return task;
        }
    }
}