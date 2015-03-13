using System;
class CheckBitAtGivenPosition
{
    /* Problem 13. Check a Bit at Given Position
     * Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n, has value of 1.
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
       
        bool isOne = bit == 1;
        Console.WriteLine("Bit #{0} is One: {1}!", position, isOne);

    }
}

