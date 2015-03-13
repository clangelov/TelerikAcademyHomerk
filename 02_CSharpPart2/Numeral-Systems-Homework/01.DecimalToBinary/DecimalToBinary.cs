/*
 * Problem 1. Decimal to binary
 * Write a program to convert decimal numbers to their binary representation.
*/
using System;
using System.Text;
class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter a deciaml number: ");
        long decNumber = long.Parse(Console.ReadLine());
        
        long remainder;
        
        StringBuilder binary = new StringBuilder();

        while (decNumber > 0)
        {
            int index = 0;                      // this will put the reminder allays at firts position                      
            remainder = decNumber % 2;
            binary.Insert(index, remainder);    // we put the remainder at firts position

            decNumber /= 2;
            index++;
        }

        Console.WriteLine("The binary number is {0}", binary);
    }
}

