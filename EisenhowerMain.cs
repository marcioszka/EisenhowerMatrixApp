using System;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            // FOR USING CSV HELPER IT IS NECCESARY TO INSTALL IT BY: dotnet add package CsvHelper
            // CSV HANDLER USAGE EXAMPLE (NO EXCEPTION HANDLING)
            // TodoMatrix taskPlanner = new TodoMatrix();
            // for (int i = 0; i < 10; i++)
            // {
            //     taskPlanner.AddItem($"Task{i}",StringHelper.GetDeadline((i + 1).ToString(), (i + 1).ToString()),i%2==1);
            // }
            // Console.WriteLine("Created planner:");
            // Display.PrintPlanner(taskPlanner);
            // CsvHandler.SaveMatrixToCsv(taskPlanner);
            // TodoMatrix readPlanner = CsvHandler.ReadMatrixFromCsv();
            // Console.WriteLine("Read planner:");
            // Display.PrintPlanner(readPlanner);
            TodoMatrix taskPlanner = new TodoMatrix();
            string userChoice = "";
            Display.PrintMessage("welcome");
            do
            {
                Display.PrintMenu();
                userChoice = Input.GetMenuOption();            
                switch (userChoice.ToUpper())
                {
                    case "A":
                        AddItemToList(taskPlanner);
                        break;
                    case "S":
                        Display.PrintPlanner(taskPlanner);  //TODO: finish displaying quarters
                        break;
                    case "D":
                        RemoveItemFromList(taskPlanner);
                        break;
                    case "C":
                        ChangeItemStatus(taskPlanner);
                        break;
                    case "R":
                        //Display from file
                        break;
                }
            }
            while (userChoice.ToUpper()!="X");
            //archive matrix
        }

        static public void AddItemToList(TodoMatrix matrix)
        {
            var title = Input.GetTaskTitle();
            var date = Input.GetTaskDate();
            var deadline = StringHelper.ParseStringToDateTime(date);
            bool isImportant = Input.GetTaskImportance();
            matrix.AddItem(title, deadline, isImportant);
            Display.PrintMessage("isAdded");
        }

        static public void RemoveItemFromList(TodoMatrix matrix)
        {
            var quarterChoice = Input.GetQuarterOption(matrix);
            var quarter = matrix.GetQuarter(quarterChoice);
            int index = Input.GetIndexOfItem();
            if (index > quarter.GetItems().Count) 
            {
                Console.Clear();
                Display.PrintMessage("noItem"); 
            }
            else 
            {
                Console.Clear();
                quarter.RemoveItem(index - 1);
                Display.PrintMessage("isRemoved");
            }
        }

        static public void ChangeItemStatus(TodoMatrix matrix)
        {
            var quarterChoice = Input.GetQuarterOption(matrix);
            var quarter = matrix.GetQuarter(quarterChoice);
            int index = Input.GetIndexOfItem();
            if (index > quarter.GetItems().Count)
            {
                Console.Clear();
                Display.PrintMessage("noItem");
            }
            else
            {
                var item = quarter.GetItem(index - 1);
                if (item.IsDone()) { item.Unmark(); }
                else { item.Mark(); }
            }
            Console.Clear();
            Display.PrintMessage("status");
        }
    }

}
