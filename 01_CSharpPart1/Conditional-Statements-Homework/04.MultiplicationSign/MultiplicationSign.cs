using System;
class MultiplicationSign
{
    /* Problem 4. Multiplication Sign
     * Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
     * Use a sequence of if operators.
    */
    static void Main()
    {
        Console.Write("a = ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("b = ");
        decimal b = decimal.Parse(Console.ReadLine());
        Console.Write("c = ");
        decimal c = decimal.Parse(Console.ReadLine());

        if ((a == 0) || (b == 0) || (c == 0))
        {
            Console.WriteLine("Result is 0");
        }
        else if ((a < 0) && (b < 0) && (c < 0))
        {
            Console.WriteLine("Result is \"-\"");
        }
        else if ((a > 0) && ((b < 0) ^ (c < 0)))
        {
            Console.WriteLine("Result is \"-\"");
        }
        else if ((b > 0) && ((a < 0) ^ (c < 0)))
        {
            Console.WriteLine("Result is \"-\"");
        }
        else if ((c > 0) && ((a < 0) ^ (b < 0)))
        {
            Console.WriteLine("Result is \"-\"");
        }
        else
        {
            Console.WriteLine("Result is \"+\"");
        }
    }
}

