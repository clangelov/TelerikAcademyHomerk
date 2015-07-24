namespace Task04.CompareSortAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal static class TestSortAlgorithms
    {
        // If tests are taking too long time to complete toy may reduce LoopsCount 
        private const int LoopsCount = 10000;
        private const int OperationRepeatCount = 10;

        private static Stopwatch watchTime = new Stopwatch();
        private static List<double> storeResults = new List<double>(OperationRepeatCount);

        internal static void TestSelectionSort<T>(T[] array, DataType data, ArrayState arrayState) where T : IComparable
        {
            storeResults.Clear();
            for (int i = 0; i < OperationRepeatCount; i++)
            {
                watchTime.Reset();
                watchTime.Start();
                for (int j = 0; j < LoopsCount; j++)
                {
                    Algorithms.SelectionSort(array);
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.TotalMilliseconds);
            }

            double averageTime = storeResults.Average();
            Console.WriteLine("Selection Sort with {0} in a {1} Array finished in {2:F2} miliseconds", data, arrayState, averageTime);
        }

        internal static void TestQuickSort<T>(T[] array, DataType data, ArrayState arrayState) where T : IComparable
        {
            storeResults.Clear();
            for (int i = 0; i < OperationRepeatCount; i++)
            {
                watchTime.Reset();
                watchTime.Start();
                for (int j = 0; j < LoopsCount; j++)
                {
                    Algorithms.Quicksort(array, 0, array.Length - 1);
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.TotalMilliseconds);
            }

            double averageTime = storeResults.Average();
            Console.WriteLine("Quick Sort with {0} in a {1} Array finished in {2:F2} miliseconds", data, arrayState, averageTime);
        }

        internal static void TestInsertionSort<T>(T[] array, DataType data, ArrayState arrayState) where T : IComparable
        {
            storeResults.Clear();
            for (int i = 0; i < OperationRepeatCount; i++)
            {
                watchTime.Reset();
                watchTime.Start();
                for (int j = 0; j < LoopsCount; j++)
                {
                    Algorithms.InsertionSort(array);
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.TotalMilliseconds);
            }

            double averageTime = storeResults.Average();
            Console.WriteLine("Insertion Sort with {0} in a {1} Array finished in {2:F2} miliseconds", data, arrayState, averageTime);
        }  
    }
}
