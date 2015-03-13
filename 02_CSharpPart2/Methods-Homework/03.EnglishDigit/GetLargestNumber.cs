/*
 * Problem 2. Get largest number
 * Write a method GetMax() with two parameters that returns the larger of two integers.
 * Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
*/
using System;
class GetLargestNumber
{
    static int GetMax(int one, int two)
    {
        return Math.Max(one, two);
    }
    static void Main()
    {
        Console.Write("Eneter number One: ");
        int numOne = int.Parse(Console.ReadLine());

        Console.Write("Eneter number Two: ");
        int numTwo = int.Parse(Console.ReadLine());

        Console.Write("Eneter number Three: ");
        int numThree = int.Parse(Console.ReadLine());

        Console.WriteLine();
        
        // Option 1
        int max = GetMax(numOne, numTwo);
        max = GetMax(numThree, max);
        Console.WriteLine("The biggest number is {0}", max);

        Console.WriteLine(new string ('-', 30));

        // Option 2
        Console.WriteLine("The biggest number is {0}", Math.Max(numThree, GetMax(numOne,numTwo)));
    }
}

