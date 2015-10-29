// We are given numbers N and M and the following operations: a) N = N+1 b) N = N+2 c) N = N*2
// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
// Hint: use a queue.
// Example: N = 5, M = 16
// Sequence: 5 → 7 → 8 → 16
namespace Task10.ShortestSequence
{
    using System;
    using System.Collections.Generic;

    public class ShortestSequence
    {
        public static void Main()
        {
            Queue<int> operations = new Queue<int>();

            int startNumber = 5;
            int endNumber = 16;

            int newTarget = endNumber;
            int multyplierCounter = 0;

            operations.Enqueue(startNumber);

            while (newTarget / 2 >= startNumber)
            {
                newTarget /= 2;
                multyplierCounter++;
            }

            while (startNumber < newTarget)
            {
                if (startNumber + 2 < newTarget)
                {
                    startNumber += 2;
                    operations.Enqueue(startNumber);
                }
                else if (startNumber < newTarget)
                {
                    startNumber++;
                    operations.Enqueue(startNumber);
                }
            }

            for (int i = 0; i < multyplierCounter; i++)
            {
                startNumber *= 2;
                operations.Enqueue(startNumber);
            }

            Console.WriteLine(string.Join(" -> ", operations));
        }
    }
}
