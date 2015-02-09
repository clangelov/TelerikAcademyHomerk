
/* Problem 10. Odd and Even Product
 * You are given n integers (given in a single line, separated by a space).
 * Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
 * Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
*/

using System;
using System.Linq;
class OddEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Enter n numbers separated with space: ");

        int[] numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int productEven = 1;
        int productOdd = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                productEven *= numbers[i];
            }
            else
            {
                productOdd *= numbers[i];
            }
        }

        if (productOdd == productEven)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("Product = {0}", productEven);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("Product of Even numbers = {0}", productEven);
            Console.WriteLine("Product of Odd numbers = {0}", productOdd);
        }
    }
}

