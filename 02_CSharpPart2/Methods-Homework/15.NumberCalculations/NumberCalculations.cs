/*
 * Problem 15.* Number calculations
 * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
*/
using System;
using System.Linq;
class IntegerCalculations
{
    // Just changing the input array to decimal and repeating the same steps from task 14
    static void FindValue(decimal[] array)
    {
        Array.Sort(array);
        Console.WriteLine("The minimum value is {0}", array[0]);
        Console.WriteLine("The maximim value is {0}", array[array.Length - 1]);
    }

    static void NumberCalculations(decimal[] array)
    {
        decimal sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        Console.WriteLine("The sum of all numbers is {0}", sum);

        decimal product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }
        Console.WriteLine("The product of all number is {0}", product);

        Console.WriteLine("The average of all numbers is {0:F5}", array.Average());
    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space to the Array: ");
        decimal [] array = Console.ReadLine()
           .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => decimal.Parse(x))
           .ToArray();

        FindValue(array);
        NumberCalculations(array);
    }
}

