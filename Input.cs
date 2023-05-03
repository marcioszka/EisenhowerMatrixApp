using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
{
    public class Input
    {
        public static string GetMenuOption()
        {
            return Console.ReadLine();
        }

        public static string GetUserInput() 
        {
            return Console.ReadLine();
        }

        public static bool GetTaskImportance()
        {
            string importance = Console.ReadLine().ToLower();
            return importance == "y" ? true : false;
        }
    }
}
