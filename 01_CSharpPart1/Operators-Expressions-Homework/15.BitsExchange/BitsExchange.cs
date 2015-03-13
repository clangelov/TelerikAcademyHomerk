using System;
class BitsExchange
{
    /* Problem 15.* Bits Exchange
     * Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
    */
    static void Main()
    {
        Console.Write("Please enter a number: ");
        uint input = uint.Parse(Console.ReadLine());

        for (int i = 3, j = 24; i < 6; i++, j++)
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

