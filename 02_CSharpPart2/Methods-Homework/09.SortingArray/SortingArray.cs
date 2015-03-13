/*
 * Problem 9. Sorting array
 * Write a method that return the maximal element in a portion of array of integers starting at given index.
 * Using it write another method that sorts an array in ascending / descending order.
*/
using System;
using System.Linq;
class SortingArray
{
    static void GetMaximalElement(int[] arr, int startIndex)
    {
        // storing the element with max value
        int maxElement = int.MinValue;
                 
        for (int i = startIndex; i < arr.Length; i++)
        {
            if (arr[i] > maxElement)
            {
                maxElement = arr[i];
            }   
        }
        Console.WriteLine("The bigest number after index {0} is {1}!", startIndex-1,maxElement);
    }

    static void OrderArray (int[] array, int startIndex)
    {
        // Sorting the array from the staring point (start index ) 
        // and than follows the length of elements to be sorted (array.Length - startIndex)
        Array.Sort(array, startIndex, array.Length - startIndex);
        array = array.ToArray();

        Console.Write("Sorted Array after index {0}: ", startIndex-1);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        // just reversing the already sorted array
        Array.Reverse(array, startIndex, array.Length - startIndex);
        array = array.ToArray();
        
        Console.Write("Order by descending Array after index {0}: ", startIndex - 1);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        // I start every search from the next element = given number +1!
        Console.Write("Enter starting index: ");
        int startIndex = int.Parse(Console.ReadLine()) + 1;

        GetMaximalElement(array, startIndex);

        OrderArray(array, startIndex);        
    }
}

