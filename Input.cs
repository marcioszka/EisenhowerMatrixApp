using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class Input
    {
        private static string[] MenuChoices = { "A", "C", "D", "R", "S", "X" };
        
        public static string GetMenuOption()
        {
            string userInput = Console.ReadLine();
            string option = userInput.ToUpper();
            while (option != "A" && option != "C" && option != "D" && option != "R" && option != "S" && option != "X")
            {
                Console.Clear();
                Display.PrintMenu();
                Display.PrintMessage("wrongInput");
                option = Console.ReadLine().ToUpper();
            }
            return option;
        }

        public static string GetTaskTitle() 
        {
            Console.Clear();
            Display.PrintMessage("title");
            return Console.ReadLine();
        }

        public static string GetTaskDate()
        {
            string date = "";
            bool isDateAccurate = false;
            do
            {
                Display.PrintMessage("day");
                string day = Console.ReadLine();
                while (!StringHelper.IsDayNumber(day))
                {
                    Console.Clear();
                    Display.PrintMessage("wrongInput");
                    day = Console.ReadLine();
                }
                Display.PrintMessage("month");
                string month = Console.ReadLine();
                while (!StringHelper.IsMonthNumber(month))
                {
                    Console.Clear();
                    Display.PrintMessage("wrongInput");
                    month = Console.ReadLine();
                }
                date = StringHelper.SetDeadlineYear(day, month);
                isDateAccurate = StringHelper.IsDateProper(day, month);
                Console.Clear();
            }
            while (!isDateAccurate);
            return date;
        }

        public static bool GetTaskImportance()
        {
            Console.Clear();
            Display.PrintMessage("importance");
            string importance = Console.ReadLine().ToLower();
            while(importance != "y" && importance != "n")
            {
                Console.Clear();
                Display.PrintMessage("wrongInput");
                importance = Console.ReadLine().ToLower();
            }
            Console.Clear();
            return importance == "y" ? true : false;
        }

        public static string GetQuarterOption(TodoMatrix matrix)
        {
            Console.Clear();
            Display.PrintPlanner(matrix);
            Display.PrintMessage("quarter");
            string userInput = Console.ReadLine();
            string quarterChoice = userInput.ToUpper();
            while (quarterChoice != "IU" && quarterChoice != "IN" && quarterChoice != "NU" && quarterChoice != "NN")
            {
                Console.Clear();
                Display.PrintMessage("wrongInput");
                Display.PrintMessage("quarter");
                quarterChoice = Console.ReadLine().ToUpper();
            }
            return quarterChoice;
        }

        public static int GetIndexOfItem()
        {
            Display.PrintMessage("index");
            string userInput = Console.ReadLine();
            while(!StringHelper.IsNumber(userInput))
            {
                Console.Clear();
                Display.PrintMessage("wrongInput");
                Display.PrintMessage("index");
                userInput = Console.ReadLine();
            }
            return StringHelper.ChangeStringToNumber(userInput);
        }
    }
}
