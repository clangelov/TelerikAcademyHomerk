namespace Task03.ReadWordsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class ReadWords
    {
        public static void Main()
        {
            string[] inputData = File.ReadAllLines("../../text.txt");

            // string[] inputData = File.ReadAllLines("../../bbcnews.txt");
            var result = new SortedDictionary<string, int>();

            for (int i = 0; i < inputData.Length; i++)
            {
                string currentLine = inputData[i];
                var expressionToMatch = @"(?<!\S)[a-z-]+(?=[,.!?:;]?(?!\S))";
                var match = Regex.Matches(currentLine, expressionToMatch);

                foreach (var item in match)
                {
                    string wordToAdd = item.ToString().ToLower();

                    if (!result.ContainsKey(wordToAdd))
                    {
                        result.Add(wordToAdd, 1);
                    }
                    else
                    {
                        result[wordToAdd] += 1;
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine("You can find the word {0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
