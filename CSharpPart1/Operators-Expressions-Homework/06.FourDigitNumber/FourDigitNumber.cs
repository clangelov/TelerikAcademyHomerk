using System;
class FourDigitNumber
{
    /* Problem 6. Four-Digit Number
     * Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
     * Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
     * Prints on the console the number in reversed order: dcba (in our example 1102).
     * Puts the last digit in the first position: dabc (in our example 1201).
     * Exchanges the second and the third digits: acbd (in our example 2101).
     * The number has always exactly 4 digits and cannot start with 0.
    */
    static void Main()
    {
        Console.Write("Please enter a four-digit number: ");
        int abcd = int.Parse(Console.ReadLine());

        int a = abcd / 1000;
        int b = (abcd % 1000) / 100;
        int c = (abcd % 100) / 10;
        int d = abcd % 10;

        Console.WriteLine("Sum of digits = " + (a + b + c + d));
        Console.WriteLine("Reversed = " + (d * 1000 + c * 100 + b * 10 + a));
        Console.WriteLine("Last digit in front = " + (d * 1000 + a * 100 + b * 10 + c));
        Console.WriteLine("Second and third digits exchanged = " + (a * 1000 + c * 100 + b * 10 + d));
    }
}

