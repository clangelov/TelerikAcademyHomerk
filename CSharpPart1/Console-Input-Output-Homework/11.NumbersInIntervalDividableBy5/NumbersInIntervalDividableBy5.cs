using System;
class NumbersInIntervalDividableBy5
{
    /* Problem 11.* Numbers in Interval Dividable by Given Number
     * Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0.
    */
    static void Main()
    {
        // I use unit, because we need positive integer numbers

        Console.Write("Start number = ");
        uint startNum = uint.Parse(Console.ReadLine());
        Console.Write("End number = ");
        uint endNum = uint.Parse(Console.ReadLine());

        uint numberOfP = (endNum / 5) - (startNum / 5);
        if (startNum % 5 == 0)
        {
            numberOfP++;
        }
        Console.WriteLine("p = {0}", numberOfP);

        for (uint i = startNum; i <= endNum; i++)
        {
            if ((i % 5) == 0)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();        
    }
}

