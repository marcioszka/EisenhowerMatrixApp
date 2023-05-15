using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp.src.EisenhowerMatrixApp.View
{
    public static class StringHelper
    {
        public static string SetDeadlineYear(string day, string month)
        {
            
            return $"{day}/{month}/2023";
        }

        public static int ChangeStringToNumber(string number)
        {
            return Convert.ToInt32(number);
        }

        public static bool IsNumber(string number, int num = 0) => int.TryParse(number, out num);

        public static bool IsDateProper(string day, string month)
        {
            if (IsMonthNumber(month) && IsDayNumber(day))
            {
                switch (ChangeStringToNumber(month))
                {
                    case 2:
                        return (ChangeStringToNumber(day) <= 28 && ChangeStringToNumber(day) >= 1);
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        return (ChangeStringToNumber(day) <= 30 && ChangeStringToNumber(day) >= 1);
                    default:
                        return (ChangeStringToNumber(day) <= 31 && ChangeStringToNumber(day) >= 1);
                }
            }
            return false;
        }
        public static bool IsDayNumber(string day) => ChangeStringToNumber(day) >=1 && ChangeStringToNumber(day) <= 31;

        public static bool IsMonthNumber(string month) => ChangeStringToNumber(month) >= 1 && ChangeStringToNumber(month) <= 12;

        public static DateTime ParseStringToDateTime(string date) => DateTime.Parse(date);  //TODO: check parsing

        public static DateTime GetDeadline(string date) => ParseStringToDateTime(date);
       
    }
}
