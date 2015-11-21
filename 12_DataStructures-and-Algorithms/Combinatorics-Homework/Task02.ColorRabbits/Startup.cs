namespace Task02.ColorRabbits
{
    using System;
    
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var answers = new int[n];

            var cache = new int[1000002];

            for (int i = 0; i < n; i++)
            {
                answers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < answers.Length; i++)
            {
                int index = answers[i] + 1;
                cache[index]++;
            }

            int rabbits = 0;

            for (int i = 0; i < cache.Length; i++)
            {
                if (cache[i] == 0)
                {
                    continue;
                }

                if (cache[i] <= i)
                {
                    rabbits += i;
                }
                else
                {
                    rabbits += (int)Math.Ceiling((double)cache[i] / i) * i;
                }
            }

            Console.WriteLine(rabbits);
        }
    }
}