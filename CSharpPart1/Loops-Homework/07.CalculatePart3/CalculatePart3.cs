
/* Problem 7. Calculate N! / (K! * (N-K)!)
 * Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.
*/

using System;
using System.Numerics;
class CalculatePart3
{
    static void Main()
    {
        Console.Write("n in the range [1-100] = ");
        int n = int.Parse(Console.ReadLine());

        while (n > 100)
        {
            Console.WriteLine("Invalid number n");
            Console.Write("Enter n in the range [1-100] = ");
            n = int.Parse(Console.ReadLine());
        }

        Console.Write("k in the range [1 < k < n < 100] = ");
        int k = int.Parse(Console.ReadLine());

        while ((k < 0) || (k > n))
        {
            Console.WriteLine("Invalid number k");
            Console.Write("Enter k in the range [1 < k < n < 100] = ");
            k = int.Parse(Console.ReadLine());
        }

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        BigInteger factorialNK = 1;
        BigInteger result = 0;

        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;

            if (i <= k)
            {
                factorialK *= i;
            }
        }

        for (int i = 1; i <= (n - k); i++)
        {
            factorialNK *= i;
        }

        result = (factorialN / (factorialK * factorialNK));

        Console.WriteLine("S = {0}", result); 
    }
}

