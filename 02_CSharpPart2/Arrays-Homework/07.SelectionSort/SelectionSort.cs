
/* Problem 7. Selection sort
 * Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
 * Use the Selection sort algorithm: 
 * Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
*/
using System;
class SelectionSort
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
        int[] array = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            array[i] = Convert.ToInt32(numbers[i]);
        }
        
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j]) // swap items
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
            }
        }
        
        // Print the answer on the console: 
        Console.Write("Sorted Array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]+ " ");
        }
        Console.WriteLine();
        
    }
}

