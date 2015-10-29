// We are given numbers N and M and the following operations: a) N = N+1 b) N = N+2 c) N = N*2
// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
// Hint: use a queue.
// Example: N = 5, M = 16
// Sequence: 5 → 7 → 8 → 16
namespace Task10.ShortestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestSequence
    {
        public static void Main()
        {
            Queue<int> operations = new Queue<int>();

            int startNumber = 5;
            int endNumber = 23;

            while (startNumber <= endNumber)
            {
                operations.Enqueue(endNumber);

                if (endNumber / 2 >= startNumber)
                {
                    if (endNumber % 2 == 0)
                    {
                        endNumber /= 2;
                    }
                    else
                    {
                        endNumber--;
                    }
                }
                else
                {
                    if (endNumber - 2 >= startNumber)
                    {
                        endNumber -= 2;
                    }
                    else
                    {
                        endNumber--;
                    }
                }
            }

            Console.WriteLine(string.Join(" -> ", operations.Reverse()));
        }
    }
}