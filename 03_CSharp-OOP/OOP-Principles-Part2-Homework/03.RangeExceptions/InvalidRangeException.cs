/*
 * Problem 3. Range Exceptions
 * Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].
*/
namespace _03.RangeExceptions
{
    using System;
    public class InvalidRangeException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRangeException(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start 
        {
            get
            {
                return this.start;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value can not be null");
                }
                this.start = value;
            } 
        }
        public T End
        {
            get
            {
                return this.end;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value can not be null");
                }
                this.end = value;
            }
        }

        public override string Message
        {
            get
            {
                return string.Format("{0} is out of the range [{1} - {2}]",
                    typeof(T).Name, this.start, this.end);
            }
        }
    }
}
