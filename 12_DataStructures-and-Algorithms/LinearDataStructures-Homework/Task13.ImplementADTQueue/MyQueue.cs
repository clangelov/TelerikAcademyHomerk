namespace Task13.ImplementADTQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyQueue<T> : IEnumerable<T>
    {
        private QueueItem<T> beginning;
        private QueueItem<T> end;

        public MyQueue()
        {
            this.Clear();
        }

        public int Count { get; private set; }

        public void Clear()
        {
            this.beginning = null;
            this.end = null;
            this.Count = 0;
        }

        public void Enqueue(T value)
        {
            var elementToAdd = new QueueItem<T>(value);

            if (this.end != null)
            {
                this.end.Next = elementToAdd;
                elementToAdd.Previous = this.end;
                this.end = elementToAdd;
            }
            else
            {
                this.beginning = this.end = elementToAdd;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.beginning == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            var result = this.beginning.Value;
            this.beginning = this.beginning.Next;
            
            if (this.beginning != null)
            {
                this.beginning.Previous = null;
            }

            this.Count--;
            return result;
        }

        public T Peek()
        {
            if (this.beginning == null)
            {
                throw new ArgumentException("The queue is empty");
            }

            return this.beginning.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var element = this.beginning;
            while (element != null)
            {
                yield return element.Value;
                element = element.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class QueueItem<T>
        {
            public QueueItem(T value)
            {
                this.Value = value;
                this.Next = null;
                this.Previous = null;
            }

            public QueueItem<T> Next { get; set; }

            public QueueItem<T> Previous { get; set; }

            public T Value { get; private set; }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }
    }
}
