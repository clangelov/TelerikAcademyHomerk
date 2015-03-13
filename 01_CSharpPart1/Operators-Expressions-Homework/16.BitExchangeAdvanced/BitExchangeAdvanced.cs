using System;

class BitExchangeAdvanced
{
    /* Problem 16.** Bit Exchange (Advanced)
     * Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
     * The first and the second sequence of bits may not overlap.
    */
    static void Main()
    {
        Console.Write("Please enter nuber: ");
        uint input = uint.Parse(Console.ReadLine());

        Console.Write("Enter starting position: ");
        int startPosition = int.Parse(Console.ReadLine());

        Console.Write("Enter starting bits for replace: ");
        int replaceBits = int.Parse(Console.ReadLine());

        Console.Write("Enter number of bits: ");
        int numberOfBits = int.Parse(Console.ReadLine());

        if (startPosition + numberOfBits > 32 || replaceBits + numberOfBits > 32)
        {
            Console.WriteLine("Result: Out of range.");
        }
        else if ((startPosition < replaceBits) && (startPosition + numberOfBits > replaceBits))
        {
            Console.WriteLine("Result: Overlapping.");
        }
        else
        {
            for (int i = startPosition, j = replaceBits; i < startPosition + numberOfBits; i++, j++)
            {
                if ((((1 << i) & input) >> i) != (((1 << j) & input) >> j))
                {
                    input = (uint)(input ^ (1 << i));
                    input = (uint)(input ^ (1 << j));
                }
            }

            Console.WriteLine("Binary result: {0}",Convert.ToString(input, 2).PadLeft(32, '0'));
            Console.WriteLine("The result is: {0}", input);
        }
    }
}

