
/* Problem 13.* Merge sort
 * Write a program that sorts an array of integers using the Merge sort algorithm.
*/
using System;
using System.Linq;
class MergeSort
{
    private static void SortArray(int[] numbers, int left, int right)
    {
        int pivot;

        if (left < right)
        {
            pivot = Partition(numbers, left, right);

            if (pivot > 1)
            {
                SortArray(numbers, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                SortArray(numbers, pivot + 1, right);
            }
        }
    }

    private static int Partition(int[] numbers, int left, int right)
    {
        int pivot = numbers[left];

        while (true)
        {
            while (numbers[left] < pivot) ++left;
            while (numbers[right] > pivot) --right;

            if (numbers[right] == numbers[left] && numbers[left] == pivot)
                ++left;

            if (left < right)
            {
                numbers[left] ^= numbers[right];
                numbers[right] ^= numbers[left];
                numbers[left] ^= numbers[right];
            }
            else
                return right;
        }
    }
    static void Main()
    {
        // Random generated Array
        Console.Write("Please eneter the size of a random genarated array: ");
        int n = int.Parse(Console.ReadLine());
        Random random = new Random();
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {           
            array[i] = random.Next(0,9);
        }
        
        Console.WriteLine("Unsorted Array:");
        // String.Join = Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
        Console.WriteLine(String.Join(", ", array));
        Console.WriteLine(new string('-', 50));
                
        SortArray(array, 0, array.Length-1);
        
        Console.WriteLine("Sorted Array:");
        Console.WriteLine(String.Join(", ", array));       
    }   
}

