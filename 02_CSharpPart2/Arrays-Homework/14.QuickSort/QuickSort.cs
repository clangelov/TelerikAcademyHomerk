
/* Problem 14. Quick sort
 * Write a program that sorts an array of integers using the Quick sort algorithm.
*/
using System;
using System.Linq;
class QuickSort
{
    public static void Quicksort(int[] elements, int left, int right)
    {
        int i = left, j = right;
        int pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap
                int tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        // Recursive calls
        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
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
            array[i] = random.Next(-9, 9);
        }

        Console.WriteLine("Unsorted Array:");        
        Console.WriteLine(String.Join(", ", array));
        Console.WriteLine(new string('-', 50));

        // Final Result
        Quicksort(array, 0, array.Length-1);
        
        Console.WriteLine("Sorted Array:");
        Console.WriteLine(String.Join(", ", array));
    }
}

