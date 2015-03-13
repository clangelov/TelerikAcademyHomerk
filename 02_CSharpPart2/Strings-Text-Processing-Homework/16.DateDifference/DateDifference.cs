/*
 * Problem 16. Date difference
 * Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
 * Example:
 * Enter the first date: 27.02.2006
    Enter the second date: 3.03.2006
    Distance: 4 days
*/
using System;
using System.Linq;
class DateDifference
{
    static void Main()
    {
        Console.WriteLine("Enter the first date  in the fromat day.month.year: ");
        int[] dateArrStart = Console.ReadLine()
            .Split('.')
            .Select(x => int.Parse(x))
            .ToArray();
        
        DateTime startDate = new DateTime(dateArrStart[2], dateArrStart[1], dateArrStart[0]);

        Console.WriteLine("Enter the second date in the format day.month.year: ");
        int[] dateArrEnd = Console.ReadLine()
            .Split('.')
            .Select(x => int.Parse(x))
            .ToArray();

        DateTime endDate = new DateTime(dateArrEnd[2], dateArrEnd[1], dateArrEnd[0]);

        int daysLenght = (endDate - startDate).Days;

        if (daysLenght >= 0)
        {
            Console.WriteLine("Distance in days: {0}", daysLenght);
        }
        else
        {
            Console.WriteLine("Invalit input");
        }
        
    }
}

