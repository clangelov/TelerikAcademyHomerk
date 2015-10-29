// Write a program that reads a sequence of integers(List<int>) ending with an empty line and sorts them in an increasing order.
namespace Task03.SortNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            List<int> listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList();

            listOfNumbers.Sort();

            Console.WriteLine("Sorted numbers {0}", string.Join(", ", listOfNumbers));
        }
    }
}
