/*
 * Problem 7. Timer
 * Using delegates write a class Timer that can execute certain method at each t seconds.
*/
namespace _07.Timer
{
    using System;
    using System.Threading;

    public delegate void TimerDelegate(int seconds);
    class Timer
    {
        private static void TestMethod(int seconds)
        {
            seconds *= 1000;
            Thread.Sleep(seconds);
            int counter = 0;
            while (counter < 5)
            {
                Thread.Sleep(seconds);
                Console.WriteLine("Called by a delegate. I will execute every {0} seconds\n", seconds / 1000);
                counter++;
            }
        }

        private static void Main()
        {
            
            // Option One 
            // TimerDelegate timeDelegate = new TimerDelegate(TestMethod);
            
            // Option two: shorter way to create the delegate
            TimerDelegate timeDelegate = TestMethod;

            // calling the method
            timeDelegate(3);

        }
    }
}
