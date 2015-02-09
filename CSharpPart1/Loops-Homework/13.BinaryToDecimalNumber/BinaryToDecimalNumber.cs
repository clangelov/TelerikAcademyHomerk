
/* Problem 13. Binary to Decimal Number
 * Using loops write a program that converts a binary integer number to its decimal form.
 * The input is entered as string. The output should be a variable of type long.
 * Do not use the built-in .NET functionality.
*/

using System;
class BinaryToDecimalNumber
{
    private static int CalculateExponent(int foundation, int exponent)
    {
        int result = 1;
        while (exponent > 0)
        {
            result *= foundation;
            exponent--;
        }
        return result;
    }
    static void Main(string[] args)
    {
        Console.Write("Enter a binary number: ");
        string binary = Console.ReadLine();
        int result = 0, foundation = 2, exponent = 1;

        if (binary == "0")
        {
            Console.WriteLine("0");
        }
        else if (binary == "1")
        {
            Console.WriteLine("1");
        }
        else
        {
            for (int i = binary.Length - 2; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    result += CalculateExponent(foundation, exponent);
                }
                exponent++;
            }

            if (binary[binary.Length - 1] == '1')
                result += 1;

            Console.WriteLine("The decimal number is {0}", result);
        }
    }
}

