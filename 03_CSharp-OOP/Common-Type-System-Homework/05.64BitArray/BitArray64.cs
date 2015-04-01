/*
 * Problem 5. 64 Bit array
 * Define a class BitArray64 to hold 64 bit values inside an ulong value.
 * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
*/
namespace _05._64BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;
        public BitArray64(ulong number)
        {
            this.Number = number;
        }
        public ulong Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive values are accepted");
                }
                this.number = value;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new System.Text.StringBuilder();
            while (this.Number != 0)
            {
                result.Insert(0, ((this.Number & 1) == 1) ? '1' : '0');
                this.Number >>= 1;
            }
            return result.ToString().PadLeft(64, '0');
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode() ^ 64;
        }

        public override bool Equals(object obj)
        {
            BitArray64 equal = obj as BitArray64;

            if (equal == null)
            {
                return false;
            }

            if (this.Number != equal.Number)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !object.Equals(first, second);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new ArgumentOutOfRangeException("Index must be in the range 0 - 63");
                }
                return ((int)(this.Number >> index) & 1);
            }

        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
