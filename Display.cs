using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class Display
    {
        private static string[] MainMenu = { "Welcome to Eisenhower Matrix App, your task planner!\n", "Choose following options:", "[A] Add new task", "[D] Display your planner", "[X] Exit application" };

        public static void PrintMenu()
        {
            foreach (string option in MainMenu)
            {
                Console.WriteLine(option);
            }
        }
    }
}
