using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrixApp
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

        public static bool IsDateProper(string day, string month)
        {
            switch (ChangeStringToNumber(month))
            {
                case 2:
                    return (ChangeStringToNumber(day) > 28 || ChangeStringToNumber(day) < 1);
                case 4:
                case 6:
                case 9:
                case 11:
                    return (ChangeStringToNumber(day) > 30 || ChangeStringToNumber(day) < 1);
                default:
                    return (ChangeStringToNumber(day) > 31 || ChangeStringToNumber(day) < 1);
            }
        }

        public static DateTime ParseStringToDateTime(string date)
        {
            return DateTime.Parse(date);    //TryParse(date, ...)
        }

        public static DateTime GetDeadline(string day, string month)
        {
            string date = SetDeadlineYear(day, month);
            return ParseStringToDateTime(date);
        }
    }
}
