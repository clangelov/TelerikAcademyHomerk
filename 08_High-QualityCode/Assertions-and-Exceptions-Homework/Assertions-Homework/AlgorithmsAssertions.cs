using System;
using System.Diagnostics;

/* Assertion is used mainly for private methods
 * Assert if they work correctly
*/
internal static class AlgorithmsAssertions
{
    internal static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");
        Debug.Assert(startIndex < endIndex, "The start index can not be larger than the end index");
        Debug.Assert(startIndex >= 0, "Start index must be greater than or equal to 0.");
        Debug.Assert(endIndex > 0, "End index must be greater than 0.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(ValidateMinElementPosition(arr, startIndex, endIndex, minElementIndex), "Minimum element is not correctly identified.");

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
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");
        Debug.Assert(startIndex < endIndex, "The start index can not be larger than the end index");
        Debug.Assert(startIndex >= 0, "Start index must be greater than or equal to 0.");
        Debug.Assert(endIndex > 0, "End index must be greater than 0.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                Debug.Assert(ValidateCorreectPositionOfElement(arr, value, midIndex), "Incorrect position of element");
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
        Debug.Assert(ValidateCorreectPositionOfElement(arr, value, -1), "Incorrect position of element");
        return -1;
    }

    private static bool ValidateMinElementPosition<T>(T[] arr, int startIndex, int endIndex, int minElementIndex) where T : IComparable<T>
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (arr[minElementIndex].CompareTo(arr[i]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValidateCorreectPositionOfElement<T>(T[] arr, T value, int result) where T : IComparable<T>
    {
        int index = Array.IndexOf(arr, value);
        if (index == result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}