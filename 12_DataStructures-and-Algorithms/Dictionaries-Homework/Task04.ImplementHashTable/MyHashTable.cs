namespace Task04.ImplementHashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyHashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const float ResizeCoeff = 0.75f;

        private LinkedList<KeyValuePair<K, V>>[] values;
        private int count;
        private int capacity;

        public MyHashTable()
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

        public K[] Keys
        {
            get
            {
                var listOfKeys = new List<K>(this.count);

                foreach (var pair in this)
                {
                    listOfKeys.Add(pair.Key);
                }

                return listOfKeys.ToArray();
            }
        }

        public V this[K key]
        {
            get
            {
                V valueToReturn = this.FindValue(key);

                return valueToReturn;
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.capacity = 16;
            this.values = new LinkedList<KeyValuePair<K, V>>[16];
        }
       
        public void Add(K key, V value)
        {
            if (this.Contains(key))
            {
                return;
            }

            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                this.values[index] = new LinkedList<KeyValuePair<K, V>>();
            }

            this.values[index].AddFirst(new KeyValuePair<K, V>(key, value));
            ++this.count;

            if (this.count > ResizeCoeff * this.capacity)
            {
                this.ResizeAndRewritte();
            }
        }

        public V FindValue(K key)
        {
            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                return default(V);
            }

            var chain = this.values[index];

            foreach (var pair in chain)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            return default(V);
        }

        public bool Contains(K key)
        {
            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                return false;
            }

            var chain = this.values[index];

            foreach (var pair in chain)
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void Remove(K key)
        {
            if (!this.Contains(key))
            {
                throw new InvalidOperationException("can not find key");
            }

            var index = this.GetIndex(key);

            var valueToRemove = this.values[index].First(item => item.Key.ToString() == key.ToString());
            this.values[index].Remove(valueToRemove);
            --this.count;

            if (this.values[index].Count == 0)
            {                
                this.values[index] = null;
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valuesList in this.values)
            {
                if (valuesList == null)
                {
                    continue;
                }

                foreach (var item in valuesList)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetIndex(K key)
        {
            var hash = key.GetHashCode();

            if (hash < 0)
            {
                hash *= -1;
            }

            var index = hash % this.values.Length;

            return index;
        }

        private void ResizeAndRewritte()
        {
            var oldvalues = (LinkedList<KeyValuePair<K, V>>[])this.values.Clone();
            this.capacity *= 2;
            this.values = new LinkedList<KeyValuePair<K, V>>[this.capacity];
            this.count = 0;

            foreach (var item in oldvalues)
            {
                if (item != null)
                {
                    foreach (var value in item)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }
    }
}
