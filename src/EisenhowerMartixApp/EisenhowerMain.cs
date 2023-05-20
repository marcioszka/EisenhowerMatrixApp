using EisenhowerMatrixApp.src.EisenhowerMatrixApp.Manager;
using EisenhowerMatrixApp.src.EisenhowerMartixApp.Model;
using EisenhowerMatrixApp.src.EisenhowerMatrixApp.View;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            EisenhowerMatrixDb database = new EisenhowerMatrixDb();
            //database.Connect();
            ITodoItemDao todoItemDao = new MssqlTodoItemDao(database.ConnectionString); //in EisenhowerMatrixDB

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
                        //AddItemToList(taskPlanner);
                        var title = Input.GetTaskTitle();
                        var date = Input.GetTaskDate();
                        var deadline = StringHelper.ParseStringToDateTime(date);
                        bool isImportant = Input.GetTaskImportance();
                        AddItem(taskPlanner, title, deadline, isImportant);
                        database.AddItemToDB(todoItemDao, title, deadline, isImportant);
                        Display.PrintMessage("isAdded");
                        break;
                    case "S":
                        Display.PrintPlanner(taskPlanner);
                        break;
                    case "D": case "C":
                        //RemoveItemFromList(taskPlanner);
                        var quarterChoice = Input.GetQuarterOption(taskPlanner);
                        var quarter = taskPlanner.GetQuarter(quarterChoice);
                        int index = Input.GetIndexOfItem();
                        var id = quarter.GetItemId(index - 1);
                        if (index > quarter.GetItems().Count)
                        {
                            Console.Clear();
                            Display.PrintMessage("noItem");
                        }
                        else
                        {
                            if (userChoice.ToUpper() == "D") 
                            {
                                Console.Clear();
                                RemoveItem(quarter, index);
                                database.RemoveItemFromDB(todoItemDao, id);
                                Display.PrintMessage("isRemoved");
                            }
                            else
                            {
                                var item = quarter.GetItem(index - 1);
                                if (item.IsDone()) { item.Unmark(); }
                                else
                                {
                                    item.Mark();
                                }
                                database.UpdateInDB(todoItemDao, item);
                            }
                        }
                        break;
                    //case "C":
                        //ChangeItemStatus(taskPlanner);
                    //    break;
                    case "R":
                        TodoMatrix readPlanner = CsvHandler.ReadMatrixFromCsv();    //TODO: read matrix from db? then another column, with quarters acronyms needed (?)
                        Display.PrintPlanner(readPlanner);
                        break;
                }
            }
            while (userChoice.ToUpper()!="X");
            //SavePlannerToFile(taskPlanner);
            Display.PrintMessage("exit");
            Environment.Exit(0);
        }

        static public void AddItem(TodoMatrix matrix, string title, DateTime deadline, bool isImportant)
        {
            matrix.AddItem(title, deadline, isImportant);
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

        static public void RemoveItem(TodoQuarter quarter, int index)
        {
            quarter.RemoveItem(index - 1);
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
    }

}
