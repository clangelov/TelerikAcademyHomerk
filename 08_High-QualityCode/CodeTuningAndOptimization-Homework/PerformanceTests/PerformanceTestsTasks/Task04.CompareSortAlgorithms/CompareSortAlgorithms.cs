namespace Task04.CompareSortAlgorithms
{
    using System;

    using Task02.CompareSimpleMaths;

    public class CompareSortAlgorithms
    {
        private const int ArraySize = 25;
        private static Random random = new Random();

        public static void Main()
        {
            int[] sampleInrArr = GenerateIntArray(ArraySize);
            double[] sampleDoubleArr = GenerateDoubletArray(ArraySize);
            string[] sampleStringArr = GenerateStringArray(ArraySize);

            CompareSimpleMaths.DrawLineOnConsole("SELECTION SORT TESTS SORTED ARR");
            TestSortAlgorithms.TestSelectionSort(sampleInrArr, DataType.Int, ArrayState.Sorted);
            TestSortAlgorithms.TestSelectionSort(sampleDoubleArr, DataType.Double, ArrayState.Sorted);
            TestSortAlgorithms.TestSelectionSort(sampleStringArr, DataType.String, ArrayState.Sorted);

            CompareSimpleMaths.DrawLineOnConsole("QUICK SORT TESTS SORTED ARR");
            TestSortAlgorithms.TestQuickSort(sampleInrArr, DataType.Int, ArrayState.Sorted);
            TestSortAlgorithms.TestQuickSort(sampleDoubleArr, DataType.Double, ArrayState.Sorted);
            TestSortAlgorithms.TestQuickSort(sampleStringArr, DataType.String, ArrayState.Sorted);

            CompareSimpleMaths.DrawLineOnConsole("INSERTION SORT TESTS SORTED ARR");
            TestSortAlgorithms.TestInsertionSort(sampleInrArr, DataType.Int, ArrayState.Sorted);
            TestSortAlgorithms.TestInsertionSort(sampleDoubleArr, DataType.Double, ArrayState.Sorted);
            TestSortAlgorithms.TestInsertionSort(sampleStringArr, DataType.String, ArrayState.Sorted);
        }

        private static int[] GenerateIntArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-10, 50);
            }

            Array.Sort(array);

            return array;
        }

        private static double[] GenerateDoubletArray(int size)
        {
            double[] array = new double[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-10, 50) * (0.45 * i);
            }

            Array.Sort(array);

            return array;
        }

        private static string[] GenerateStringArray(int size)
        {
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                char add = (char)random.Next(65, 90);
                array[i] = new string(add, 5) + i.ToString();
                random.Next(-10, 50).ToString();
            }

            Array.Sort(array);

            return array;
        }
    }
}
