namespace Task05.ImplementSet
{
    using System.Collections;
    using System.Collections.Generic;
    using Task04.ImplementHashTable;

    public class MyHashSet<T> : IEnumerable<T>
    {
        private MyHashTable<int, T> values;
        private int count;

        public MyHashSet()
        {
            this.Clear();
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.values = new MyHashTable<int, T>();
        }

        public void Add(T value)
        {
            int key = this.GetHashCode(value);
            this.values.Add(key, value);
            ++this.count;
        }

        public T Find(T value)
        {
            int key = this.GetHashCode(value);
            return this.values[key];
        }

        public void Remove(T value)
        {
            int key = this.GetHashCode(value);
            this.values.Remove(key);
            --this.count;
        }
        
        public MyHashSet<T> Intersect(MyHashSet<T> other)
        {
            var result = new MyHashSet<T>();

            foreach (var item in this.values)
            {
                foreach (var otherItem in other.values)
                {
                    if (item.Key == otherItem.Key)
                    {
                        result.Add(item.Value);
                    }
                }
            }

            return result;
        }

        public MyHashSet<T> Union(MyHashSet<T> other)
        {
            var result = new MyHashSet<T>();

            foreach (var item in this.values)
            {
                result.Add(item.Value);
            }

            foreach (var item in other.values)
            {
                if (!result.values.Contains(item.Key))
                {
                    result.Add(item.Value);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.values)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        private int GetHashCode(T value)
        {
            int hash = value.GetHashCode();

            if (hash < 0)
            {
                hash *= -1;
            }

            return hash;
        }
    }
}
