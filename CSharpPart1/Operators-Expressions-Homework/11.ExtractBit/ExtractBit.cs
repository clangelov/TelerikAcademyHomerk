using System;
class ExtractBit
{
    /* Problem 11. Bitwise: Extract Bit #3
     * Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
     * The bits are counted from right to left, starting from bit #0.
     * The result of the expression should be either 1 or 0.
    */
    static void Main()
    {
        int number, position, mask, numberAndMask, bit;
        Console.Write("Please enter a number: ");
        number = int.Parse(Console.ReadLine());
        position = 3;
        mask = 1 << position;        
        numberAndMask = number & mask;  
        bit = numberAndMask >> position;
        Console.WriteLine("Bit #3 is {0}", bit);

    }
}

