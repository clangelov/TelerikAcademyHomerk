namespace Task11.ImplementLinkedList
{
    public class MyListItem<T>
    {
        private T value;
        private MyListItem<T> nextItem;

        public MyListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }

        public MyListItem(T value, MyListItem<T> prevItem)
        {
            this.Value = value;
            prevItem.NextItem = this;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public MyListItem<T> NextItem
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }
    }
}
