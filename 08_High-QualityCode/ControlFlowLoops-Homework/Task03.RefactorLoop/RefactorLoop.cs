namespace Task03.RefactorLoop
{
    using System;

    public class RefactorLoop
    {
        private const int LoopsCount = 100;
        private const int ExpectedValue = 5;

        public static void Main()
        {
            int[] numbers = GenerateArray(LoopsCount);

            for (int i = 0; i < LoopsCount; i++)
            {
                if (numbers[i] == ExpectedValue)
                {
                    Console.WriteLine("Expected value found at index {0}", i);
                    break;
                }
                else
                {
                    Console.WriteLine("Still searching at index {0}", i);
                }
            }   
        }

        private static int[] GenerateArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
