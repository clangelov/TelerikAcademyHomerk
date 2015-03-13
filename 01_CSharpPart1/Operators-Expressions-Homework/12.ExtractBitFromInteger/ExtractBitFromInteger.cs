using System;
class ExtractBitFromInteger
{
    /* Problem 12. Extract Bit from Integer
     * Write an expression that extracts from given integer n the value of given bit at index p.
    */
    static void Main()
    {
        int number, position, mask, numberAndMask, bit;
        Console.Write("Please enter a number: ");
        number = int.Parse(Console.ReadLine());
        Console.Write("Enter Bit Position: ");
        position = int.Parse(Console.ReadLine());
        mask = 1 << position;
        numberAndMask = number & mask;
        bit = numberAndMask >> position;
        Console.WriteLine("Bit #{0} is {1}", position, bit);
    }
}

