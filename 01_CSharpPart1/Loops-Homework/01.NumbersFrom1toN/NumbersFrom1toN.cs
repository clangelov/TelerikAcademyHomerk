
/* Problem 1. Numbers from 1 to N
 * Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space.
*/

using System;
class NumbersFrom1toN
{
    static void Main()
    {
        Console.Write("Enter number n = ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
}

