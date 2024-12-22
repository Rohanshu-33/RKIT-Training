using System;

namespace CSharp_Basics
{
    internal class DateTimeClassDemo
    {
        internal static void DateTimeClassMethods()
        {
            //DateTime dt = new DateTime();  // immutable
            //Console.WriteLine(dt);  // default date and time

            //DateTime specificDate = new DateTime(2024, 12, 15);  // yr,mon,date
            //DateTime specificDateWithTime = new DateTime(2024, 12, 15, 14, 45, 33);  // + hour,min,sec
            //Console.WriteLine(specificDate);
            //Console.WriteLine(specificDateWithTime);

            //DateTime current = DateTime.Now;
            //Console.WriteLine(current);

            //DateTime dt = DateTime.UtcNow;
            //Console.WriteLine(dt.ToString() + $" {dt.ToString().GetType()}");
            //Console.WriteLine(dt + $" {dt.GetType()}");

            //DateTime now = DateTime.Now;
            //DateTime tomorrow = now.AddDays(1);

            //DateTime nextHour = now.AddHours(1);
            //DateTime nextHourTomorrow = tomorrow.AddHours(7);

            //TimeSpan difference = nextHourTomorrow - now;
            //Console.WriteLine(difference);

            //int compare = DateTime.Compare(now, now);
            //switch (compare)
            //{
            //    case 0:
            //        Console.WriteLine("Same dates");
            //        break;
            //    case 1:
            //        Console.WriteLine("first param big");
            //        break;
            //    case -1:
            //        Console.WriteLine("second param big");
            //        break;
            //    default:
            //        Console.WriteLine("Default");
            //        break;
            //}


            //string dateString = "2024-12-15";
            //DateTime parsedDate = DateTime.Parse(dateString);

            //Console.WriteLine(parsedDate);

            //DateTime tmp = parsedDate.AddMinutes(90);
            //Console.WriteLine(tmp);

            //DateTime updatedDateTime = parsedDate.AddHours(7).AddMicroseconds(245).AddMinutes(25).AddMonths(4);
            //Console.WriteLine(updatedDateTime);

            //bool isLeapYear = DateTime.IsLeapYear(2024);
            //Console.WriteLine(isLeapYear);

            //DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            //Console.WriteLine(dayOfWeek);

            //string formattedDate = DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss");
            //Console.WriteLine("Formatted Date: " + formattedDate);

            //TimeSpan tmp = DateTime.Now.TimeOfDay;
            //Console.WriteLine(tmp);
        }
    }
}
