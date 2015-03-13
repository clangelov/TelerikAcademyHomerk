/* 
 * Problem 18.* Remove elements from array
 * Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order.
 * Print the remaining sorted array.
 * Example:
 * Input: 6, 1, 4, 3, 0, 3, 6, 4, 5     Result: 1, 3, 3, 4, 5 
*/
using System;
using System.Linq;
class RemoveElementsFromArray
{
    static int[] LongestIncSubsequence(int[] array)
    {
        int[] increasingLengths = new int[array.Length];
        increasingLengths[0] = 1;
        for (int i = 1; i < increasingLengths.Length; i++)
        {
            int maxLength = 0;
            for (int j = 0; j < i; j++)
            {
                if (array[j] <= array[i] && increasingLengths[j] > maxLength)
                {
                    maxLength = increasingLengths[j];
                }
            }
            increasingLengths[i] = maxLength + 1;
        }

        int[] sortedSubset = new int[increasingLengths.Max()];
        int serialNumber = increasingLengths.Max();

        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (serialNumber == increasingLengths[i])
            {
                sortedSubset[serialNumber - 1] = array[i];
                serialNumber--;
            }
        }

        return sortedSubset;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] arr = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray(); 

        int[] result = LongestIncSubsequence(arr);

        Console.WriteLine(new string('-', 30));

        Console.WriteLine("The result is: {0}", String.Join(",", result));
    }
}

