using System;
class NumberAsWords
{
    /* Problem 11.* Number as Words
     * Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
    */
    static void Main()
    {
        int hundreds, tens, ones, number;

        Console.Write("Please enter a number in the rage [0-999]: ");
        number = int.Parse(Console.ReadLine());

        hundreds = number / 100;
        tens = (number % 100) / 10;
        ones = number % 10;

        if (hundreds > 0)
        {
            switch (hundreds)
            {
                case 1:
                    Console.Write("One Hundred "); break;
                case 2:
                    Console.Write("Two Hundred "); break;
                case 3:
                    Console.Write("Three Hundred "); break;
                case 4:
                    Console.Write("Four Hundred "); break;
                case 5:
                    Console.Write("Five Hundred "); break;
                case 6:
                    Console.Write("Six Hundred "); break;
                case 7:
                    Console.Write("Seven Hundred "); break;
                case 8:
                    Console.Write("Eight Hundred "); break;
                case 9:
                    Console.Write("Nine Hundred "); break;
                default:
                    Console.WriteLine(); break;
            }
            if ((tens == 0 && ones > 0) || tens == 1)
            {
                Console.Write("and ");
            }
        }

        if (tens == 1)
        {
            switch (ones)
            {
                case 0:
                    Console.Write("Ten\n"); break;
                case 1:
                    Console.Write("Eleven\n"); break;
                case 2:
                    Console.Write("Twelve\n"); break;
                case 3:
                    Console.Write("Thirteen\n"); break;
                case 4:
                    Console.Write("Fourteen\n"); break;
                case 5:
                    Console.Write("Fifteen\n"); break;
                case 6:
                    Console.Write("Sixteen\n"); break;
                case 7:
                    Console.Write("Seventeen\n"); break;
                case 8:
                    Console.Write("Eighteen\n"); break;
                case 9:
                    Console.Write("Nineteen\n"); break;
                default:
                    Console.WriteLine(); break;
            }
        }

        if (tens > 1)
        {
            switch (tens)
            {
                case 2:
                    Console.Write("Twenty "); break;
                case 3:
                    Console.Write("Thirty "); break;
                case 4:
                    Console.Write("Fourty "); break;
                case 5:
                    Console.Write("Fifty "); break;
                case 6:
                    Console.Write("Sixty "); break;
                case 7:
                    Console.Write("Seventy "); break;
                case 8:
                    Console.Write("Eighty "); break;
                case 9:
                    Console.Write("Ninety "); break;
                default:
                    Console.WriteLine(); break;
            }
        }

        if (tens != 1)
        {
            switch (ones)
            {
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
                    Console.WriteLine(); break;
            }
        }

        if (hundreds == 0 && tens == 0 && ones == 0)
        {
            Console.WriteLine("Zero");
        }
    }
}

