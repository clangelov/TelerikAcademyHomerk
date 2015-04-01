namespace _05._64BitArray
{
    using System;
    class Test64BitArray
    {
        static void Main()
        {
            var firstBit64 = new BitArray64(int.MaxValue);

            // Use IEnumerable to foreach the elements in the BitArray64
            Console.Write("firstBit64:  ");
            foreach (var bit in firstBit64)
            {
                Console.Write(bit);
            }

            // Use BitArray64.ToString to print the second bitarray
            var secondBit64 = new BitArray64(long.MaxValue);
            Console.WriteLine("\nsecondBit64: {0}", secondBit64);

            // Test BitArray64.Equals, ==, != 
            Console.WriteLine();
            Console.WriteLine("firstBit64.equals(secondBit64) = {0}!", firstBit64.Equals(secondBit64));
            if (firstBit64 != secondBit64)
            {
                Console.WriteLine("Two different values");
            }
            else
            {
                Console.WriteLine("Two identical values");    
            }

            // Test BitArray64.GetHashCode
            Console.WriteLine();
            Console.WriteLine("firstBit64  HashCode: {0}", firstBit64.GetHashCode());
            Console.WriteLine("secondBit64 HashCode: {0}", secondBit64.GetHashCode());

            // Test indexers
            Console.WriteLine();
            Console.WriteLine("firstBit64[0]  = {0}", firstBit64[0]);
            Console.WriteLine("secondBit64[0] = {0}", secondBit64[0]);
        }
    }
}
