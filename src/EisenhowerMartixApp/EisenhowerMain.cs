using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using EisenhowerMatrixApp.src.EisenhowerMatrixApp.Manager;
using EisenhowerMatrixApp.src.EisenhowerMartixApp.Model;
using EisenhowerMatrixApp.src.EisenhowerMatrixApp.View;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            ConnectToDatabase();
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
                        Display.PrintPlanner(taskPlanner);
                        break;
                    case "D":
                        RemoveItemFromList(taskPlanner);
                        break;
                    case "C":
                        ChangeItemStatus(taskPlanner);
                        break;
                    case "R":
                        TodoMatrix readPlanner = CsvHandler.ReadMatrixFromCsv();
                        Display.PrintPlanner(readPlanner);
                        break;
                }
            }
            while (userChoice.ToUpper()!="X");
            //SavePlannerToFile(taskPlanner);
            Display.PrintMessage("exit");
            Environment.Exit(0);
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

        static public void SavePlannerToFile(TodoMatrix matrix)
        {
            matrix.ArchiveItems();
            CsvHandler.SaveMatrixToCsv(matrix);
            Display.PrintMessage("plannerSaved");
        }

        static public void ConnectToDatabase()
        {
            EisenhowerMatrixDb database = new EisenhowerMatrixDb();
            database.Connect();
        }
    }

}
