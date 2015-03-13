/* 
 * Problem 10. N Factorial
 * Write a program to calculate n! for each n in the range [1..100].
*/
using System;
using System.Numerics;
class NFactorial
{
    static BigInteger FactorialN (int factorial)
    {
        // The bottom of the recursion
        if (factorial == 0)
        {
            return 1;
        }
        // Recursive call: the method calls itself
        else
        {
            return factorial * FactorialN(factorial - 1);
        }        
    }
    static void Main()
    {
        Console.Write("Please enter n! in the rage [1..100] = ");
        int factorial = int.Parse(Console.ReadLine());

        Console.Write("{0}! = ", factorial);
        Console.WriteLine(FactorialN(factorial));
    }
}

