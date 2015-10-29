// Implement the ADT queue as dynamic linked list.
namespace Task13.ImplementADTQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var testQueue = new MyQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                testQueue.Enqueue((i + 1) * 10);
            }

            Console.WriteLine("You have {0} elements in the queue", testQueue.Count);

            int size = testQueue.Count;
            for (int i = 0; i < size; i++)
            {
                var firstElemnet = testQueue.Dequeue();
                Console.WriteLine("Removing the element at the begining {0}", firstElemnet);
            }

            Console.WriteLine("You have {0} elements in the queue", testQueue.Count);
        }
    }
}
