namespace Task11.PermutationsWithRepetitions
{
    using System;

    public class Startup
    {
        private static int[] array;

        public static void Main()
        {
            // array = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5  };
            array = new int[] { 3, 5, 1, 5 };
                        
            Array.Sort(array);

            PermuteWithRepetitions(array, 0);
        }

        private static void PermuteWithRepetitions(int[] array, int startIndex)
        {
            Console.WriteLine(string.Format("{{{0}}}", string.Join(", ", array)));

            for (int left = array.Length - 2; left >= startIndex; left--)
            {
                for (int right = left + 1; right < array.Length; right++)
                {
                    if (array[left] != array[right])
                    {
                        var oldValue = array[left];
                        array[left] = array[right];
                        array[right] = oldValue;
                        PermuteWithRepetitions(array, left + 1);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = array[left];
                for (int i = left; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[array.Length - 1] = firstElement;
            }
        }
    }
}
