/* 
 * Problem 8. Number as array
 * Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
 * Each of the numbers that will be added could have up to 10 000 digits.
*/
using System;
using System.Linq;
using System.Numerics;
class NumberAsArray
{
    // It works only with positive integeger numbers  
    static void ArrayCalculation(BigInteger one, BigInteger two)
    {
        string numOne = Convert.ToString(one);
        string numTwo = Convert.ToString(two);

        // making the two string the same size + one extra 0 in the front
        if (numOne.Length >= numTwo.Length)
        {
            numTwo = numTwo.PadLeft(numOne.Length + 1, '0');
            numOne = numOne.PadLeft(numOne.Length + 1, '0');
        }
        else if (numOne.Length < numTwo.Length)
        {
            numOne = numOne.PadLeft(numTwo.Length + 1, '0');
            numTwo = numTwo.PadLeft(numTwo.Length + 1, '0');
        }

        // creating an array who will store the result
        int[] result = new int[numOne.Length];

        int[] arrayOne = new int[numOne.Length];
        int[] arrayTwo = new int[numTwo.Length];

        // converting from string to int array
        for (int i = 0; i < arrayOne.Length; i++)
        {
            arrayOne[i] = numOne[i] - '0';
        }

        for (int i = 0; i < arrayTwo.Length; i++)
        {
            arrayTwo[i] = numTwo[i] - '0';
        }

        // making the calculation and storing it to array result
        for (int i = result.Length - 1; i >= 0; i--)
        {
            int temp = arrayOne[i] + arrayTwo[i];

            if (temp > 9)
            {
                result[i] = temp % 10;
                arrayOne[i - 1] = arrayOne[i - 1] + 1;
            }
            else
            {
                result[i] = temp;
            }
        }

        // if we have a leading 0 in the result we just skip it
        if (result[0] == 0)
        {
            result = result.Skip(1).ToArray();

        }

        // printing the result
        Console.Write("Result is: ");
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.WriteLine("Eneter a integer number one:");
        BigInteger numOne = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine("Eneter a integer number two:");
        BigInteger numTwo = BigInteger.Parse(Console.ReadLine());

        ArrayCalculation(numOne, numTwo);
    }
}