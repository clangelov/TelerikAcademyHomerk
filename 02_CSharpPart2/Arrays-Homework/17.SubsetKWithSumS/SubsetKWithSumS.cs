
/* Problem 17.* Subset K with sum S
 * Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
 * Find in the array a subset of K elements that have sum S or indicate about its absence.
*/
using System;
using System.Linq;

class SubsetKWithSumS
{
    static int wantedSum;
    static int elements;
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
        if (elementsInSubset != elements)
        {
            return;
        }
        int sum = 0;
        for (int i = 0; i < elementsInSubset; i++)
        {
            sum += subset[i];
        }
        if (sum == wantedSum)
        {
            Console.Write("Yes, the numbers giving {0} using {1} elements are: ", wantedSum,elements);
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

        Console.Write("Enter number of elements to form the sum: ");
        elements = int.Parse(Console.ReadLine());

        int[] subset = new int[array.Length];

        for (int elementsInSubset = 1; elementsInSubset <= array.Length; elementsInSubset++)
        {
            GenerateSubset(array, subset, 0, 0, elementsInSubset);
        }

        if (!solution)
        {
            Console.WriteLine("No subset with sum {0} with {1}, elements.", wantedSum, elements);
        }
    }
}

