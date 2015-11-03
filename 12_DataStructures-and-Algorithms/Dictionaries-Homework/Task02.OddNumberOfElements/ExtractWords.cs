namespace Task02.OddNumberOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtractWords
    {
        public static void Main()
        {
            // C#, SQL, PHP, PHP, SQL, SQL
            List<string> listOfWords = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .GroupBy(x => x)
               .Where(gr => gr.Count() % 2 != 0)
               .Select(x => x.Key)
               .ToList();
            
            Console.WriteLine(string.Join(", ", listOfWords));
        }
    }
}
