/*
 * Problem 4. Hexadecimal to decimal
 * Write a program to convert hexadecimal numbers to their decimal representation.
*/
using System;
class HexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Enter a hexadecimal integer number: ");
        string hex = Console.ReadLine();
        
        // making shure thath all leters are Capital
        hex = hex.ToUpper();

        long number = 0;
        long power = 1;

        // for cycle starintg from the last element of the string hex
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            int sign;
            
            switch (hex[i])
            {
                case 'A': sign = 10;
                    break;
                case 'B': sign = 11;
                    break;
                case 'C': sign = 12;
                    break;
                case 'D': sign = 13;
                    break;
                case 'E': sign = 14;
                    break;
                case 'F': sign = 15;
                    break;
                default: sign = hex[i] - 48; // This will give us all numnbers from 0 to 9
                    break;
            }
            number += sign * power;
            
            power *= 16;
        }

        Console.WriteLine("The decimal number is: {0}", number);
    }
}

