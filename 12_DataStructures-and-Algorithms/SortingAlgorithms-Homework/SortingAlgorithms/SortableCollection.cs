namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private Random random = new Random();
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool found = false;

            for (int i = 0; i < this.items.Count; i++)
            {
                if (item.CompareTo(this.items[i]) == 0)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public bool BinarySearch(T item)
        {
            bool result = this.BinarySearchRecursive(item, 0, this.items.Count - 1);
            return result;
        }

        private bool BinarySearchRecursive(T value, int left, int right)
        {
            if (right < left)
            {
                return false;
            }
            int middle = (left + right) / 2;
            if (this.items[middle].CompareTo(value) > 0)
            {
                return BinarySearchRecursive(value, left, middle - 1);
            }
            else if (this.items[middle].CompareTo(value) < 0)
            {
                return BinarySearchRecursive(value, middle + 1, right);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Fisher-Yates Shuffle.
        /// </summary>
        public void Shuffle()
        {
            int n = this.items.Count - 1;
            for (int i = 0; i <= n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                if (r != i)
                {
                    T temp = this.items[r];
                    this.items[r] = this.items[i];
                    this.items[i] = temp;
                }
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
