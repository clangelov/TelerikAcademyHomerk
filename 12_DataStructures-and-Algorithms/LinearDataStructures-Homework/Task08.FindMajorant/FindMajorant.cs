// *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
namespace Task08.FindMajorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindMajorant
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            List<int> listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList();

            var result = listOfNumbers
                .GroupBy(x => x)
                .Where(gr => gr.Count() > listOfNumbers.Count / 2)
                .FirstOrDefault();

            Console.WriteLine("The mahorant in the array {0}", result == null ? "does not exist" : "is " + result.Key);
        }
    }
}
