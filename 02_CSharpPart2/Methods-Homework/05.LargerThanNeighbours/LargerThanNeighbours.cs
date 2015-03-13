/*
 * Problem 5. Larger than neighbours
 * Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
*/
using System;
using System.Linq;
class LargerThanNeighbours
{
    static void CompareToNeighbours (int[] array, int position)
    {
        if (position <= 0 || position >= array.Length-1)
        {
            Console.WriteLine("There are no two elements to be compared!");
        }
        else
        {
            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                Console.WriteLine("The number {0} at position {1} is larger then its neighboiurs", array[position], position);
            }
            else
            {
                Console.WriteLine("The number {0} at position {1} is NOT larger then its neighboiurs", array[position], position);    
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        Console.Write("Enter the position of the element: ");
        int position = int.Parse(Console.ReadLine());

        CompareToNeighbours(array, position);
    }
}

