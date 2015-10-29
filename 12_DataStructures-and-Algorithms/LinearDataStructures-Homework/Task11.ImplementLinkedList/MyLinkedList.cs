namespace Task11.ImplementLinkedList
{
    using System.Collections;
    using System.Collections.Generic;

    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyListItem<T> firstElement;
        private MyListItem<T> tailElement;
        private int count;

        public MyLinkedList()
        {
            this.count = 0;
            this.firstElement = null;
            this.tailElement = null;
        }

        public void Add(T value)
        {
            if (firstElement == null)
            {
                firstElement = new MyListItem<T>(value);
                tailElement = firstElement;
            }
            else
            {
                var newListItem = new MyListItem<T>(value, tailElement);
                tailElement = newListItem;
            }
            count++;
        }

        public int Count()
        {
            return this.count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.FirstElement;
            if (currentElement != null)
            {
                yield return currentElement.Value;
            }

            while (currentElement.NextItem != null)
            {
                currentElement = currentElement.NextItem;
                yield return currentElement.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public MyListItem<T> FirstElement
        {
            get { return this.firstElement; }
            set { this.firstElement = value; }
        }
    }
}
