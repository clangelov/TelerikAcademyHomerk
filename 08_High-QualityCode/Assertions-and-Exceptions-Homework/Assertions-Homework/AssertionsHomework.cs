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

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = HelpAlgorithms.FindMinElementIndex(arr, index, arr.Length - 1);
            HelpAlgorithms.Swap(ref arr[index], ref arr[minElementIndex]);
        }

        AssertIfArrayIsSorted(arr);
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");

        int result = HelpAlgorithms.BinarySearch(arr, value, 0, arr.Length - 1);

        AssertCorreectPositionOfElement(arr, value, result);

        return result;
    }

    private static void AssertIfArrayIsSorted<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Array is not sorted.");
        }
    }

    private static void AssertCorreectPositionOfElement<T>(T[] arr, T value, int result) where T : IComparable<T>
    {
        int index = Array.IndexOf(arr, value);
        Debug.Assert(index == result, "Incorrect position of element");
    }
}
