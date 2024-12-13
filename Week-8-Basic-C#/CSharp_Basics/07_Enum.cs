using System;

namespace CSharp_Basics
{
    internal class Enumeratorss
    {
        enum Days
        {
            sun=1, mon, tue, wed, thu, fri, sat
        }
        public static void EnumsDemo()
        {
            Days today = Days.fri;
            int todayNum = (int)Days.fri;
            Days tomorrow = (Days)(todayNum+1);
            Console.WriteLine(today + " " + todayNum + " " + tomorrow);
        }
    }
}
