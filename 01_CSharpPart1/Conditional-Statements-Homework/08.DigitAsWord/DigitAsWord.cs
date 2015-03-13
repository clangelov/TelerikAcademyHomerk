using System;
class DigitAsWord
{
    /* Problem 8. Digit as Word
     * Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
     * Print “not a digit” in case of invalid input.
     * Use a switch statement.
    */
    static void Main()
    {
        Console.Write("Please enter a number: ");
        string text = Console.ReadLine();
        int number;

        if (int.TryParse(text, out number))
        // With TryParse I check for valid number  
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("Zero"); break;
                case 1:
                    Console.WriteLine("One"); break;
                case 2:
                    Console.WriteLine("Two"); break;
                case 3:
                    Console.WriteLine("Three"); break;
                case 4:
                    Console.WriteLine("Four"); break;
                case 5:
                    Console.WriteLine("Five"); break;
                case 6:
                    Console.WriteLine("Six"); break;
                case 7:
                    Console.WriteLine("Seven"); break;
                case 8:
                    Console.WriteLine("Eight"); break;
                case 9:
                    Console.WriteLine("Nine"); break;
                default:
                    Console.WriteLine("Not a digit"); break;
            }
        }
        else
        {
            Console.WriteLine("Not a digit");
        }
    }
}

