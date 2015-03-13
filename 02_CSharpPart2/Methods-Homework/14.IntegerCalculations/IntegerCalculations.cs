/*
 * Problem 14. Integer calculations
 * Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
 * Use variable number of arguments
*/
using System;
using System.Linq;
class IntegerCalculations
{
    static void FindValue (int[] array)
    {
        // When the array is sorted at Index 0 is the smallest number and at index array.Length-1 is the biggest 
        Array.Sort(array);
        Console.WriteLine("The minimum value is {0}", array[0]);
        Console.WriteLine("The maximim value is {0}", array[array.Length-1]);
        
    }

    static void NumberCalculations(int[] array)
    {
        // using for cycle to find the sum and product of numbers in the array
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        Console.WriteLine("The sum of all numbers is {0}", sum);

        long product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }
        Console.WriteLine("The product of all number is {0}", product);

        // array.Average() finds the average for all numbers
        Console.WriteLine("The average of all numbers is {0:0}", array.Average());
    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        FindValue(array);
        NumberCalculations(array);
    }
}

