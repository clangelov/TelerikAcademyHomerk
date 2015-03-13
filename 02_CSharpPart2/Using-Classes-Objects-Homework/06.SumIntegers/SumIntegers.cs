/*
 * Problem 6. Sum integers
 * You are given a sequence of positive integer values written into a string, separated by spaces.
 * Write a function that reads these values from given string and calculates their sum.
 * Example
 * input	            output
 * "43 68 9 23 318"     461
*/
using System;
using System.Linq;
class SumIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter ints separated by space:");

        int[] array = Console.ReadLine()
                .Split(new char[] { ' ','"' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        
        // array.Sum() sums all numbers from a given array
        Console.WriteLine("The total sum is {0}", array.Sum());
    }
}

