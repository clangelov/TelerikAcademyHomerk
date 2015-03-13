
/* Problem 11. Random Numbers in Given Range
 * Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max].
*/

using System;
class RandomNumbersInGivenRange
{
    static void Main()
    {
        int n, min, max, random;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());
        Console.Write("min = ");
        min = int.Parse(Console.ReadLine());
        Console.Write("max = ");
        max = int.Parse(Console.ReadLine());

        Random number = new Random();

        if (min != max)
        {
            for (int i = 0; i < n; i++)
            {
                random = number.Next(min, max+1);
                Console.Write("{0} ", random);
            }
        }        
    }
}

