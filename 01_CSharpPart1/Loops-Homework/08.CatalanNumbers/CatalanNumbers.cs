
/* Problem 8. Catalan Numbers
 * Write a program to calculate the nth Catalan number by given n (1 < n < 100).
*/

using System;
using System.Numerics;
class CatalanNumbers
{
    static void Main()
    {
        Console.Write("N in the range [1-100] = ");
        int n = int.Parse(Console.ReadLine());

        while ((n > 100) || (n < 0))
        {
            Console.WriteLine("Invalid number n");
            Console.Write("Enter n in the range [1-100] = ");
            n = int.Parse(Console.ReadLine());
        }

        BigInteger factorial2N = 1;
        BigInteger factorialN1 = 1;
        BigInteger factorialN = 1;
        BigInteger result = 0;

        for (int i = 1; i <= 2 * n; i++)
        {
            factorial2N *= i;
        }

        for (int i = 1; i <= (n + 1); i++)
        {
            factorialN1 *= i;
        }

        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;
        }

        result = factorial2N / (factorialN1 * factorialN);

        Console.WriteLine("S = {0}", result); 
    }
}
