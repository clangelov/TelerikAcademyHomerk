/*
 * Problem 6. Divisible by 7 and 3
 * Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
*/
namespace _06.DivisibleBy7And3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class DivisibleBy7And3
    {
        static void Main()
        {
            // creating a List of numbers to be tested
            List<int> numbers = new List<int>();
            for (int i = 1; i < 101; i++)
            {
                numbers.Add(i * 3);
            }

            // Lambda expressions - 3x7 = 21
            var resultLambda = numbers.Where(x => x % 21 == 0);

            Console.WriteLine(string.Join(", ", resultLambda));

            Console.WriteLine();

            // LINQ
            var resultLINQ = from number in numbers
                             where number % 21 == 0
                             select number;

            Console.WriteLine(string.Join(", ", resultLINQ));
        }
    }
}
