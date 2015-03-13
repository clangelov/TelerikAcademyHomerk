/*
 * Problem 17. Date in Bulgarian
 * Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
*/
using System;
using System.Linq;
using System.Threading;
using System.Globalization;

class DateInBulgarian
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        Console.WriteLine("Enter the first date  in the fromat day.month.year hour:minute:second: ");
        int[] dateArrStart = Console.ReadLine()
            .Split(new char[]{'.', ' ', ':'}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        DateTime startDate = new DateTime(dateArrStart[2], dateArrStart[1], dateArrStart[0],
            dateArrStart[3], dateArrStart[4], dateArrStart[5]);

        startDate = startDate.AddHours(6).AddMinutes(30);

        Console.Write(startDate + " ");
        Console.WriteLine(startDate.ToString("dddd"));
    }
}

