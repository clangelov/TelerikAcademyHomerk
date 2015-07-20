using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    // No Input Validations
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        int arrayLength = arr.Length - 1;
        for (int index = 0; index < arrayLength; index++)
        {
            int minElementIndex = AlgorithmsAssertions.FindMinElementIndex(arr, index, arrayLength);
            AlgorithmsAssertions.Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(ValidateIfArrayIsSorted(arr), "Array is not sorted.");
    }

    // No Input Validations
    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        int startIndex = 0;
        int endIndex = arr.Length - 1;
        int result = AlgorithmsAssertions.BinarySearch(arr, value, startIndex, endIndex);       

        return result;
    }

    private static bool ValidateIfArrayIsSorted<T>(T[] arr) where T : IComparable<T>
    {
        bool isSorted = true; 

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i].CompareTo(arr[i + 1]) > 0)
            {
                isSorted = false;
            }
        }

        return isSorted;
    }
}
