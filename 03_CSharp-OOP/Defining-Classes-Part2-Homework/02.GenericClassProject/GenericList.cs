/*
 * Problem 5. Generic class
 * Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
 * Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
 * Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString().
 * Check all input parameters to avoid accessing elements at invalid positions.
*/
namespace _02.GenericClassProject
{
    using System;
    using System.Text;
    class GenericList<T>
        where T : IComparable // Generic constraints
    {
        private T[] elements;
        private int count = 0; 
        private int capacity;

        // you can not create a GenericList without giving an initial capacity
        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            elements = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        // this method will add the element at the end of the array
        public void Add(T addElement)
        {
            // check if there is enough free space in the array
            if (count >= Capacity)
            {
                AutoGrow();
            }
            this.elements[count] = addElement;
            this.count++;
        }

        // removing element by index
        public void RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
            }
            //re-write all elements with one positon forward 
            for (int i = index; i < this.count - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
            this.count--;
        }

        // inserting element at given position
        public void InsertAt(int index, T addElement)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
            }

            if ((count + 1) >= elements.Length)
            {
                AutoGrow();
            }

            if (index == count)
            {
                elements[index] = addElement;
                count++;
                return;
            }

            //re-write all elements with one positon backwards, and only after that operation adding the new one 
            for (int i = count - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }

            elements[index] = addElement;
            count++;
        }

        public void ClearList()
        {
            // this will save the elements, but they can not be accessed
            count = 0;
        }

        // finding element by its value
        public int FindElementIndex(T findElement)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].Equals(findElement))
                {
                    return i; // this will return the index of the element
                }
            }
            return -1; 
        }
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                T result = elements[index];
                return result;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (count > 0)
            {
                for (int i = 0; i < this.count; i++)
                {
                    result.AppendFormat("{0}", this.elements[i]);
                    if (i + 1 < this.count)
                    {
                        result.Append(", ");
                    }
                }

                return result.ToString();
            }
            else
            {
                return "The Generic List is empty";
            }
        }

        // Problem 6. Auto-grow
        // Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
        private void AutoGrow()
        {
            T[] newArr = new T[this.Capacity * 2];

            Array.Copy(this.elements, newArr, count);

            this.elements = newArr;
            this.Capacity *= 2;
        }

        /*
         * Problem 7. Min and Max
         * Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
         * You may need to add a generic constraints for the type T.
        */
        public T MinT()
        {
            if (this.count == 0)
            {
                throw new ApplicationException("Searching min value in an empty Generic List!");
            }

            // setting initial value and than comparing all elements of the array
            T min = elements[0];

            for (int i = 1; i < this.count; i++)
            {
                if (min.CompareTo(elements[i]) > 0)
                {
                    min = elements[i];
                }
            }

            return min;
        }

        public T MaxT()
        {
            if (this.count == 0)
            {
                throw new ApplicationException("Searching max value in an empty Generic List!");
            }

            T max = elements[0];

            for (int i = 1; i < this.count; i++)
            {
                if (max.CompareTo(elements[i]) < 0)
                {
                    max = elements[i];
                }
            }

            return max;
        }
    }
}
