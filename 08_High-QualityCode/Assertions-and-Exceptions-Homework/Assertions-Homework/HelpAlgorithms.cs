/* Those methods will always get invalid data, 
 * so there is no need to assert it
 */
using System;

internal static class HelpAlgorithms
{
    internal static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    internal static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    internal static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}