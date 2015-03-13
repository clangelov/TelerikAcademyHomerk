
/* Problem 16.* Subset with sum S
 * We are given an array of integers and a number S.
 * Write a program to find if there exists a subset of the elements of the array that has a sum S.
 * Example:
 *      input array	                S	    result
        2, 1, 2, 4, 3, 5, 2, 6	    14	    yes 
*/
using System;
using System.Linq;

class SubsetSum
{
    static int wantedSum;
    static bool solution = false;

    static void GenerateSubset(int[] arr, int[] subset, int index, int current, int elementsInSubset)
    {
        if (index == elementsInSubset)
        {
            CheckSubsets(subset, elementsInSubset);
            return;
        }

        for (int i = current; i < arr.Length; i++)
        {
            subset[index] = arr[i];
            GenerateSubset(arr, subset, index + 1, i + 1, elementsInSubset);
        }
    }

    static void CheckSubsets(int[] subset, int elementsInSubset)
    {
        int sum = 0;
        for (int i = 0; i < elementsInSubset; i++)
        {
            sum += subset[i];
        }
        if (sum == wantedSum)
        {
            Console.Write("Yes, the numbers giving {0} are: ", wantedSum);
            for (int i = 0; i < elementsInSubset; i++)
            {
                Console.Write("{0} ", subset[i]);
            }
            Console.WriteLine();
            solution = true;
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x)) 
           .ToArray(); 

        Console.Write("Enter sum S: ");
        wantedSum = int.Parse(Console.ReadLine());

        int[] subset = new int[array.Length];

        for (int elementsInSubset = 1; elementsInSubset <= array.Length; elementsInSubset++)
        {
            GenerateSubset(array, subset, 0, 0, elementsInSubset);                       
        }

        if (!solution)
        {
            Console.WriteLine("No subset with sum {0}.", wantedSum);
        }
    }
}