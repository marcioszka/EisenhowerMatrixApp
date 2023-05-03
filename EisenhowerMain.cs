using System;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class EisenhowerMain
    {
        static public void Main(string[] args)
        {
            TodoMatrix taskPlanner = new TodoMatrix();
            var userChoice = "";
            do
            {
                Display.PrintMenu();
                userChoice = Input.GetMenuOption();
            
                switch (userChoice.ToUpper())
                {
                    case "A":
                        Display.PrintMessage("title");
                        var title = Input.GetUserInput();
                        //bool isDateOK = false;        //TODO: validate date and numbers/letters
                        //do {
                        Display.PrintMessage("day");
                        var day = Input.GetUserInput();
                        Display.PrintMessage("month");
                        var month = Input.GetUserInput();
                        var isDateOK = StringHelper.IsDateProper(day, month);
                        // }
                        //while(!isDateOK);
                        var deadline = StringHelper.GetDeadline(day, month);
                        Display.PrintMessage("importance");
                        var isImportant = Input.GetTaskImportance();
                        taskPlanner.AddItem(title, deadline, isImportant);
                        break;
                    case "S":
                        Display.PrintPlanner(taskPlanner);  //TODO: finish displaying quarters
                        break;
                    case "D":
                        Display.PrintMessage("quarter");
                        var quarterChoice = Input.GetUserInput();
                        var quarter = taskPlanner.GetQuarter(quarterChoice);
                        Display.PrintMessage("index");
                        var indexChoice = Input.GetUserInput();
                        var index = StringHelper.ChangeStringToNumber(indexChoice);
                        quarter.RemoveItem(index - 1);      //TODO: walidacja indexu a liczby elementów z listy
                        break;
                    case "C":
                        Display.PrintMessage("quarter");
                        var quarterChoiceC = Input.GetUserInput();
                        var quarterC = taskPlanner.GetQuarter(quarterChoiceC);
                        Display.PrintMessage("index");
                        var indexChoiceC = Input.GetUserInput();
                        var indexC = StringHelper.ChangeStringToNumber(indexChoiceC);
                        if(quarterC.GetItem(indexC - 1).GetStatus()) { quarterC.GetItem(indexC - 1).Unmark(); }
                        else { quarterC.GetItem(indexC - 1).Mark(); }
                        break;
                }
            }
            while (userChoice.ToUpper()!="X");

        }
    }
}
