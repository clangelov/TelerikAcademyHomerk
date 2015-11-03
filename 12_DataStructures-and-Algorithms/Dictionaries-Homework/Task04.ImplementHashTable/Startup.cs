namespace Task04.ImplementHashTable
{
    using System;
    using System.Text;

    public class Startup
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private static Random random = new Random();

        public static void Main()
        {
            var myTable = new MyHashTable<string, int>();
            myTable.Add("John", 6);
            myTable.Add("Marie", 8);
            myTable.Add("Kristen", 10);
            myTable.Add("Lars", 5);

            Console.WriteLine("Initial table element count {0}", myTable.Count);

            myTable.Remove("John");

            Console.WriteLine("Elemnt count after removing one {0}", myTable.Count);

            Console.WriteLine("Is Kristen in this HashTable? - {0}", myTable.Contains("Kristen") ? "YES" : "NO");

            for (int i = 0; i < 50; i++)
            {
                myTable.Add(GetRandomString(2, 50), (i + 1) * 5);
            }

            var elementWithKey = myTable["Lars"];
            Console.WriteLine("myTable[\"Lars\"] has a value of {0}", elementWithKey);
           
            Console.WriteLine("All elements in the HashTable");
            foreach (var item in myTable)
            {
                Console.WriteLine("Key is {0} and value is {1}", item.Key, item.Value);
            }        
        }

        private static string GetRandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = random.Next(minLength, maxLength);
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var currenRandomSymbol = Alphabet[random.Next(0, Alphabet.Length)];
                result.Append(currenRandomSymbol);
            }

            return result.ToString();
        }
    }
}
