// Write a program that removes from given sequence all numbers that occur odd number of times.
namespace Task06.RemoveNumbersFromSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNumbersThatOccurOddNumberOfTimes
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            List<int> listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList();

            var groupedNumbers = listOfNumbers
                .GroupBy(x => x)
                .Where(gr => gr.Count() % 2 == 0)
                .SelectMany(x => Enumerable.Repeat(x.Key, x.Count()).ToArray())
                .ToList();
           
            Console.WriteLine(string.Join(", ", groupedNumbers));
        }
    }
}
