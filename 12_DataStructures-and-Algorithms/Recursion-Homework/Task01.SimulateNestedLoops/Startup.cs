namespace Task01.SimulateNestedLoops
{
    using System;

    public class Startup
    {
        private static int[] array;

        public static void Main()
        {
            Console.Write("Please enter the number of loops to be simulated: ");
            int loopsNumber = int.Parse(Console.ReadLine());
            array = new int[loopsNumber]; 
            SimulateLoops(0, array);
        }

        private static void SimulateLoops(int index, int[] array)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
            }
            else
            {
                for (int i = 1; i <= array.Length; i++)
                {
                    array[index] = i;
                    SimulateLoops(index + 1, array);
                }
            }
        }
    }
}
