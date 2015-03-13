
/* Problem 9. Matrix of Numbers
 * Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix like in the examples below. Use two nested loops.
*/

using System;
class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("n in the range [1 = n = 20] = ");
        int n = int.Parse(Console.ReadLine());

        while ((n > 20) || (n < 1))
        {
            Console.WriteLine("Invalid number n");
            Console.Write("Enter n in the range [1 = n = 20] = ");
            n = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 5*n; i++)
        {
            int start = i + 1;

            for (int j = 0; j < n; j++)
            {
                Console.Write(start + " ");
                start++;
            }

            Console.WriteLine();
        }  
    }
}

