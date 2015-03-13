
/* Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N
 * Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
 * Use only one loop. Print the result with 5 digits after the decimal point.
*/

using System;
class CalculateNX
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("x = ");
        int x = int.Parse(Console.ReadLine());

        decimal xAtPowerN = 1.00m;
        decimal factorial = 1.00m;
        decimal sum = 1.00m;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            xAtPowerN *= x;
            sum += (factorial / xAtPowerN);
        }
        
        Console.WriteLine("S = {0 :F5}", sum);
    }
}

