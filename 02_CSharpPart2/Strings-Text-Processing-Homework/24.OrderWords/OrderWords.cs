/*
 * Problem 24. Order words
 * Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
*/
using System;
using System.Linq;
class OrderWords
{
    static void Main()
    {
        Console.WriteLine("Enter words separated by space:");
        string[] inputWords = Console.ReadLine()
            .Split(new char[] {' ', '.', ','},StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Array.Sort(inputWords);

        Console.WriteLine("Sorted words:");

        Console.WriteLine(String.Join(", ", inputWords));
    }
}

