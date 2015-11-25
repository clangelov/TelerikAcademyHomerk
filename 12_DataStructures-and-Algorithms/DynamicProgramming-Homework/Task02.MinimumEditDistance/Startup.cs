namespace Task02.MinimumEditDistance
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var cost = new Cost()
            {
                Replace = 1.0,
                Delete = 0.9,
                Insert = 0.8
            };

            string firstWord = "developer";
            string secondWord = "enveloped";

            Console.WriteLine("{0} -> {1} = {2}", firstWord, secondWord, MinEditDistance(firstWord, secondWord, cost));
        }

        private static double MinEditDistance(string firstWord, string secondWord, Cost cost)
        {
            var d = new double[firstWord.Length + 1, secondWord.Length + 1];

            for (int i = 0; i <= firstWord.Length; i++)
            {
                d[i, 0] = i * cost.Delete;
            }

            for (int j = 0; j <= secondWord.Length; j++)
            {
                d[0, j] = j * cost.Insert;
            }

            for (int j = 1; j <= secondWord.Length; j++)
            {
                for (int i = 1; i <= firstWord.Length; i++)
                {
                    if (firstWord[i - 1] == secondWord[j - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];  // no operation
                    }
                    else
                    {
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j] + cost.Delete, d[i, j - 1] + cost.Insert), d[i - 1, j - 1] + cost.Replace);
                    }
                }
            }

            return d[firstWord.Length, secondWord.Length];
        }    
    }
}
