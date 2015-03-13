/*
 * Problem 11. Format number
 * Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
 * Format the output aligned right in 15 symbols.
*/
using System;
class FormatNumber
{
    static void Main()
    {
        Console.Write("Enter a integrer Number: ");
        int inputNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("{0,15:0.00}", inputNumber);
        Console.WriteLine("{0,15:X}", inputNumber);
        Console.WriteLine("{0,15:P}", inputNumber/100.0);
        Console.WriteLine("{0,15:E}", inputNumber);
    }
}

