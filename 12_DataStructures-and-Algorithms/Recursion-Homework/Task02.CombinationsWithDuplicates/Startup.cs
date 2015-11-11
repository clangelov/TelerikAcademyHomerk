namespace Task02.CombinationsWithDuplicates
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int[] array;

        public static void Main()
        {
            Console.Write("Please enter n and k separted by space or coma: ");
            var userInput = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int endNum = userInput[0];
            int size = userInput[1];
            array = new int[size];
            GenerateCombinations(array, 0, 1, endNum);
        }

        private static void GenerateCombinations(int[] array, int index, int startNum, int endNum)
        {
            if (index >= array.Length)
            {
                Console.WriteLine("(" + string.Join(", ", array) + ")");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    array[index] = i;
                    GenerateCombinations(array, index + 1, i, endNum);
                }
            }
        }
    }
}
