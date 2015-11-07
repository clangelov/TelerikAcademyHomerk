namespace Task01.ImplementPriorityQueue
{
    using System;

    public class MyPriorityQueue<T> where T : IComparable<T>
    {
        private MyBinaryHeap<T> heap;

        public MyPriorityQueue(bool isMinComparison)
        {
            this.heap = new MyBinaryHeap<T>(isMinComparison);
        }

        public int Count
        {
            get
            {
                return this.heap.Size;
            }
        }

        public T Peek()
        {
            return this.heap.First;
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            T element = this.heap.First;
            this.heap.RemoveFirst();
            return element;
        }
    }
}
