/*
 * Problem 3. Day of week
 * Write a program that prints to the console which day of the week is today
 * Use System.DateTime.
*/
using System;
using System.Globalization;
using System.Threading;
class DayOfWeek
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Today is: ");
        Console.WriteLine(DateTime.Now.ToString("dddd"));

        Console.WriteLine();
    }
}

