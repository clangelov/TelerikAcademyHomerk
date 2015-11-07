namespace Task01.ImplementPriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Startup
    {
        public static void Main()
        {
            var items = new[] { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };
            Console.WriteLine("Items: {0}", string.Join(", ", items));

            OrderAscending(items);
            OrderDescending(items);
        }

        private static void OrderDescending(int[] items)
        {
            var queue = new MyPriorityQueue<int>(true);

            // check if the item with the highest priority is at the top of the queue
            var minItem = int.MaxValue;
            foreach (var item in items)
            {
                queue.Enqueue(item);
                minItem = Math.Min(item, minItem);
                Debug.Assert(queue.Peek() == minItem);
            }

            // Items should be sorted in ascending order
            
            List<int> sorted = DequeueElemets(queue);
            while (queue.Count > 0)
            {
                sorted.Add(queue.Dequeue());
            }

            Console.WriteLine("Queue items ascending order: {0}", string.Join(", ", sorted));
        }

        private static void OrderAscending(int[] items)
        {
            var queue = new MyPriorityQueue<int>(false);

            // check if the item with the highest priority is at the top of the queue
            var minItem = int.MinValue;
            foreach (var item in items)
            {
                queue.Enqueue(item);
                minItem = Math.Max(item, minItem);
                Debug.Assert(queue.Peek() == minItem);
            }

            // Items should be sorted in descending order
            List<int> sorted = DequeueElemets(queue);

            Console.WriteLine("Queue items descending order: {0}", string.Join(", ", sorted));
        }

        private static List<int> DequeueElemets(MyPriorityQueue<int> queue)
        {
            var sorted = new List<int>();

            while (queue.Count > 0)
            {
                sorted.Add(queue.Dequeue());
            }

            return sorted;
        }
    }
}
