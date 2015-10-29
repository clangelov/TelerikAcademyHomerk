// Write a program that removes from given sequence all negative numbers.
namespace Task05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNegativeNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            List<int> listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList();

            Console.WriteLine("Initial collection is: {0}", string.Join(", ", listOfNumbers));

            listOfNumbers = listOfNumbers.Where(x => x > 0).ToList();

            Console.WriteLine("Collection without negative numbers {0}", string.Join(", ", listOfNumbers));
        }
    }
}
