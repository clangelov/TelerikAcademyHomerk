namespace Task05.AllOrderedElements
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static string[] result;
        private static string[] set;

        public static void Main()
        {
            Console.Write("Please Enter k: ");

            // int k = 2;
            int k = int.Parse(Console.ReadLine());

            Console.Write("Please Enter a set of words separated by space or coma: ");

            // set = new string[] { "hi", "a", "b" };
            set = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            result = new string[k];

            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Format("{{{0}}}", string.Join(", ", result)));
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    result[index] = set[i];
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }
    }
}
