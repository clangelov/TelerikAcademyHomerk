// We are given the following sequence:
// S1 = N;
// S2 = S1 + 1;
// S3 = 2*S1 + 1;
// S4 = S1 + 2;
// S5 = S2 + 1;
// S6 = 2*S2 + 1;
// S7 = S2 + 2;
// Using the Queue<T> class write a program to print its first 50 members for given N.
// Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
namespace Task09.SolveSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolveSequence
    {
        private static readonly int MaxSequenceCount = 50;
             
        public static void Main()
        {
            Console.Write("Please enter the start integrer for the sequence: ");
            int startNumber = int.Parse(Console.ReadLine());

            Queue<int> numbers = new Queue<int>();
            var result = GetSequence(startNumber);

            Console.WriteLine("Result sequence is {0}", string.Join(", ", result));
        }

        private static List<int> GetSequence(int startNumber)
        {
            List<int> result = new List<int>();
            result.Add(startNumber);

            Queue<int> numbersInSequence = new Queue<int>();
            numbersInSequence.Enqueue(startNumber);

            var currentSequenceCount = 1;

            while (currentSequenceCount < MaxSequenceCount)
            {
                int numToOperateOn = numbersInSequence.Dequeue();

                numbersInSequence.Enqueue(numToOperateOn + 1);
                numbersInSequence.Enqueue((2 * numToOperateOn) + 1);
                numbersInSequence.Enqueue(numToOperateOn + 2);

                result.Add(numbersInSequence.First());
                currentSequenceCount++;
            }

            return result;
        }
    }
}
