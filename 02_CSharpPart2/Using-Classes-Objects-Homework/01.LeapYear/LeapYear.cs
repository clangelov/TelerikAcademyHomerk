/*
 * Problem 1. Leap year
 * Write a program that reads a year from the console and checks whether it is a leap one.
 * Use System.DateTime.
*/
using System;
class LeapYear
{
    static void Main()
    {
        Console.Write("Please enter an year: ");
        int year = int.Parse(Console.ReadLine());

        if (year < 1 || year > 9999)
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        Console.WriteLine("{0} is a leap year: {1}!", year, DateTime.IsLeapYear(year));
    }
}

