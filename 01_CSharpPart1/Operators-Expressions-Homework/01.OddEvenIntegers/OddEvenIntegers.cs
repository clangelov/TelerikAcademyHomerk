using System;
class OddEvenIntegers
{
    /* Problem 1. Odd or Even Integers
     * Write an expression that checks if given integer is odd or even.
    */
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());

        bool result = (number % 2 == 0);
        Console.WriteLine("The number is odd: {0}!", ! result);
       
    }
}

