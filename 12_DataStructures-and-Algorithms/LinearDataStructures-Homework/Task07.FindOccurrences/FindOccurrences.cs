// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
namespace Task07.FindOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindOccurrences
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            List<int> listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .Where(x =>  0 < x && x < 1001)
               .ToList();

            var result = new Dictionary<int, int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                int numberToAdd = listOfNumbers[i];
                if (!result.ContainsKey(numberToAdd))
                {
                    result.Add(numberToAdd, 1);
                }
                else
                {
                    result[numberToAdd] += 1;
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine("You can find the number {0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
