namespace Task01.ImplementPriorityQueue
{
    using System;

    public class MyBinaryHeap<T> where T : IComparable<T>
    {
        private const int InitialSize = 16;

        private T[] data;
        private int index;
        private bool isMinComparison;

        public MyBinaryHeap(bool compare)
        {
            this.data = new T[InitialSize];
            this.isMinComparison = compare;
            this.index = 0;
        }

        public int Size
        {
            get
            {
                return this.index;
            }
        }

        public T First
        {
            get
            {
                if (this.data[0] == null)
                {
                    throw new ArgumentNullException("There are no elements in the BinaryHeap");
                }

                return this.data[0];
            }
        }

        public void Add(T element)
        {
            if (this.index == this.data.Length)
            {
                this.Resize();
            }

            this.data[this.index] = element;

            this.ArrangeElementsOnAdd(this.index);

            this.index++;
        }

        public void RemoveFirst()
        {
            var swapper = this.data[0];
            this.data[0] = this.data[this.index - 1];
            this.data[this.index - 1] = swapper;

            this.index--;

            this.ArrangeElementsOnDelete(0);
        }

        private void ArrangeElementsOnDelete(int index)
        {
            var left = (index * 2) + 1;
            var right = left + 1;

            if (left < this.index)
            {
                var comparison = this.data[index].CompareTo(this.data[left]);

                if (this.isMinComparison ? comparison > 0 : comparison < 0)
                {
                    var swapper = this.data[index];
                    this.data[index] = this.data[left];
                    this.data[left] = swapper;

                    this.ArrangeElementsOnDelete(left);
                }
                else if (right < this.index)
                {
                    comparison = this.data[index].CompareTo(this.data[right]);
                    if (this.isMinComparison ? comparison > 0 : comparison < 0)
                    {
                        var swapper = this.data[index];
                        this.data[index] = this.data[right];
                        this.data[right] = swapper;

                        this.ArrangeElementsOnDelete(right);
                    }
                }
            }
        }

        private void ArrangeElementsOnAdd(int index)
        {
            var parentElement = (index - 1) / 2;

            var comparison = this.data[index].CompareTo(this.data[parentElement]);

            if (this.isMinComparison ? comparison < 0 : comparison > 0)
            {
                var swapper = this.data[index];
                this.data[index] = this.data[parentElement];
                this.data[parentElement] = swapper;

                this.ArrangeElementsOnAdd(parentElement);
            }
        }

        private void Resize()
        {
            var newData = new T[this.data.Length * 2];
            Array.Copy(this.data, newData, this.data.Length);
            this.data = newData;
        }
    }
}
