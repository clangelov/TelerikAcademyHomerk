namespace Task06.AllSubsetsOfKStrings
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] result;
        private static string[] set;
        private static bool[] used;

        public static void Main()
        {
            Console.Write("Please Enter k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Please Enter a set of words separated by space or coma: ");
            set = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            result = new string[k];
            used = new bool[set.Length];

            GenerateVariationsNoRepetitions(0);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Format("{{{0}}}", string.Join(", ", result)));
            }
            else
            {
                for (int i = index; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        result[index] = set[i];
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
