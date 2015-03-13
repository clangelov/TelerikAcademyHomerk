/*
 * Problem 4. Appearance count
 * Write a method that counts how many times given number appears in given array.
 * Write a test program to check if the method is workings correctly.
*/
using System;
using System.Linq;
class AppearanceCount
{
    static void NumberCount (int[] array, int number)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (number == array[i])
            {
                counter++;
            }
        }
        Console.WriteLine("Number {0} appears {1} times in the array", number, counter);

    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        Console.Write("For which number are you looking: ");
        int number = int.Parse(Console.ReadLine());

        NumberCount(array, number);
    }
}

