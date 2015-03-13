/* 
 * Problem 6. First larger than neighbours
 * Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
*/
using System;
using System.Linq;
class FirstLargerThanNeighbours
{
    static int FindFirstLarger (int[] array)
    {
        bool result = false;
        int position = 0;
        for (int i = 1; i < array.Length-1; i++)
        {
            if (array[i] > array[i - 1] && array[i] > array[i + 1])
            {
                result = true;
                position = i;
                break;
            }
        }
        if (!result)
        {
            position = -1;
        }
        return position;
    }
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();
        
        if (FindFirstLarger(array) > 0)
        {
            Console.WriteLine("At index {0} the number is larger than its neighbours", 
                FindFirstLarger(array));
        }
        else
        {
            Console.WriteLine("Index is {0} and there are no number larger than its neighbours", 
                FindFirstLarger(array));
        }
        
    }
}

