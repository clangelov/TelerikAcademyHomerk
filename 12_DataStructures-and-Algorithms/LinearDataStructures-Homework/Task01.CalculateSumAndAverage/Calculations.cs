// Write a program that reads from the console a sequence of positive integer numbers.
// - The sequence ends when empty line is entered.
// - Calculate and print the sum and average of the elements of the sequence.
// - Keep the sequence in List<int>.
namespace Task01.CalculateSumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Calculations
    {
        public static void Main()
        {
            Console.WriteLine("Please enter some integrer numbers each of them on a new line:");

            var numbers = new List<int>();

            while (true)
            {
                var consoleInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(consoleInput))
                {
                    CalculateSumOfNumbers(numbers);
                    CalculateAvrgOfNumbers(numbers);
                    break;
                }
                else
                {
                    numbers.Add(int.Parse(consoleInput));
                }                
            }
        }

        private static void CalculateAvrgOfNumbers(List<int> numbers)
        {
            var avrg = numbers.Average();
            Console.WriteLine("The average of all numbers is {0:F2}", avrg);
        }

        private static void CalculateSumOfNumbers(List<int> numbers)
        {
            var sum = numbers.Sum();
            Console.WriteLine("The sum of all numbers is {0}", sum);
        }
    }
}
