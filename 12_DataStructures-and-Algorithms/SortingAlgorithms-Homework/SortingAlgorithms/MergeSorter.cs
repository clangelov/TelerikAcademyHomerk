namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            SortArray(collection, 0, collection.Count - 1);
        }

        private static void SortArray(IList<T> collection, int left, int right)
        {
            int pivot;

            if (left < right)
            {
                pivot = Partition(collection, left, right);

                if (pivot > 1)
                {
                    SortArray(collection, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    SortArray(collection, pivot + 1, right);
                }
            }
        }

        private static int Partition(IList<T> collection, int left, int right)
        {
            T pivot = collection[left];

            while (true)
            {
                while (collection[left].CompareTo(pivot) < 0)
                {
                    ++left;
                }

                while (collection[right].CompareTo(pivot) > 0)
                {
                    --right;
                }

                if (collection[right].CompareTo(collection[left]) == 0 && collection[left].CompareTo(pivot) == 0)
                {
                    ++left;
                }

                if (left < right)
                {
                    var temp = collection[right];
                    collection[right] = collection[left];
                    collection[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
