
/* Problem 11. Binary search
 * Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.
*/
using System;
using System.Linq;
class BinarySearch
{
    static int BinarySearchRecursive(int[] array, int value, int low, int high)
    {
        if (high < low)
        {
            return -1;
        }
        int middle = (low + high) / 2;
        if (array[middle] > value)
        {
            return BinarySearchRecursive(array, value, low, middle - 1);
        }
        else if (array[middle] < value)
        {
            return BinarySearchRecursive(array, value, middle + 1, high);
        }
        else
        {
            return middle;
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries) 
           .Select(x => int.Parse(x)) 
           .ToArray(); 

        // Sorting the array with the method .Sort
        Array.Sort(array);

        Console.Write("You want ot know the index of which element: ");
        int element = int.Parse(Console.ReadLine());

        // Here we can use the method .BinarySearch 
        Console.WriteLine("Element {0} is on index {1}", element, Array.BinarySearch(array, element));

        // Result with the BinarySearchRecursive
        
        Console.WriteLine(new string('-', 50));
        int index = BinarySearchRecursive(array, element, 0, array.Length - 1);
        Console.WriteLine("Element {0} is on index {1}", element, index);
    } 
}
