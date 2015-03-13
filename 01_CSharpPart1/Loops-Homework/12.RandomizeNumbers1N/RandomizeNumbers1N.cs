
/* Problem 12.* Randomize the Numbers 1…N
 * Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
*/

using System;
class RandomizeNumbers1N
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        int[] pool = new int[n];
        bool[] printed = new bool[n + 1];

        Random rnd = new Random();

        int randomized = rnd.Next(1, n + 1);

        for (int index = 0; index < n; index++)
        {
            randomized = rnd.Next(1, n + 1);

            if (!printed[randomized])
            {
                Console.Write("{0} ", randomized);
                printed[randomized] = true;
            }            
            else
            {
                index--;
            }
        }
        Console.WriteLine();
    }
}

