/* 
 * Problem 2. Random numbers
 * Write a program that generates and prints to the console 10 random values in the range [100, 200].
*/
using System;
class RandomNumbers
{
    static Random random = new Random();
    static void Main()
    {       

        Console.WriteLine("10 random generated numbers in the range 100 - 200");
        
        for (int i = 0; i < 10; i++)
        {
            Console.Write(random.Next(100, 201) + " ");
        }

        Console.WriteLine();
    }
}

