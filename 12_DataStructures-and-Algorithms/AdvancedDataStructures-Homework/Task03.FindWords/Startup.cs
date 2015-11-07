namespace Task03.FindWords
{
    using System;
    using System.IO;
    using TrieImplementation;

    public class Startup
    {
        public static void Main()
        {
            // Data structure trie is from: https://github.com/rmandvikar/csharp-trie          
            var wordCollection = ReadBookFromFile();

            Console.WriteLine("You can find the word and {0} times", wordCollection.WordCount("and"));

            Console.WriteLine("Is the word colony in the text {0}", wordCollection.HasWord("colony") ? "YES" : "NO");

            var words = wordCollection.GetWords("te");
            Console.WriteLine("All words starting with \"te\":");
            Console.WriteLine(string.Join(", ", words));
        }

        private static ITrie ReadBookFromFile()
        {
            ITrie trie = TrieFactory.CreateTrie();

            using (var reader = new StreamReader("../../book.txt"))
            {
                string line = reader.ReadLine();
                while (line != "@END@")
                {
                    var match = line.Split(new[] { ',', '.', '!', '?', ':', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string item in match)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            trie.AddWord(item);
                        }                       
                    }

                    line = reader.ReadLine();
                }
            }

            return trie;
        }
    }
}
