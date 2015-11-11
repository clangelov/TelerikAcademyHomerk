namespace Task04.AllVariations
{
    using System;

    public class Startup
    {
        private static int[] resultArray;
        private static bool[] usedArray;

        public static void Main()
        {
            Console.Write("Please enter n: ");
            int userInput = int.Parse(Console.ReadLine());
            resultArray = new int[userInput];
            usedArray = new bool[userInput];

            VariationsWithoutRepetion(0);
        }

        private static void VariationsWithoutRepetion(int index)
        {
            if (index >= resultArray.Length)
            {
                Console.WriteLine("(" + string.Join(", ", resultArray) + ")");
            }
            else
            {
                for (int i = 0; i < resultArray.Length; i++)
                {
                    if (!usedArray[i])
                    {
                        usedArray[i] = true;
                        resultArray[index] = i;
                        VariationsWithoutRepetion(index + 1);
                        usedArray[i] = false;
                    }
                }
            }
        }
    }
}
