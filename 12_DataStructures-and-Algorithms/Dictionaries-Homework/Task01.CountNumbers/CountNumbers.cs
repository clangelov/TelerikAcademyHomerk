namespace Task01.CountNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountNumbers
    {
        public static void Main()
        {
            // 3, 4, 4, -2,5, 3, 3, 4, 3, -2,5
            double[] listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => double.Parse(x))
               .ToArray();

            var result = new Dictionary<double, int>();

            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                double numberToAdd = listOfNumbers[i];
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
