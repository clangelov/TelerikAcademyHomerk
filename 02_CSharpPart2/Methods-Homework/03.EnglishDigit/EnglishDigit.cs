/*
 * Problem 3. English digit
 * Write a method that returns the last digit of given integer as an English word.
 *  input	output
    512	    two
    1024	four
    12309	nine
*/
using System;
class EnglishDigit
{
    static void LastDigitName (int number)
    {
        number = number % 10;

        switch (number)
        {
            case 0:
                Console.WriteLine("Last digit is: Zero"); break;
            case 1:
                Console.WriteLine("Last digit is: One"); break;
            case 2:
                Console.WriteLine("Last digit is: Two"); break;
            case 3:
                Console.WriteLine("Last digit is: Three"); break;
            case 4:
                Console.WriteLine("Last digit is: Four"); break;
            case 5:
                Console.WriteLine("Last digit is: Five"); break;
            case 6:
                Console.WriteLine("Last digit is: Six"); break;
            case 7:
                Console.WriteLine("Last digit is: Seven"); break;
            case 8:
                Console.WriteLine("Last digit is: Eight"); break;
            case 9:
                Console.WriteLine("Last digit is: Nine"); break;
            default:
                Console.WriteLine("Not a digit"); break;
        }
    }
    static void Main()
    {
        Console.Write("Please eneter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine();

        LastDigitName(number);
    }
}

