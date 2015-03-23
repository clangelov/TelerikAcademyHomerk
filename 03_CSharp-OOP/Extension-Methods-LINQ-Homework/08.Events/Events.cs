/*
 * Problem 8.* Events
 * Read in MSDN about the keyword event in C# and how to publish events.
 * Re-implement the above using .NET events and following the best practices.
*/
namespace _08.Events
{
    using System;
    using System.Collections.Generic;
    class Events
    {
        static void Main()
        {
            Publisher publisher = new Publisher();
            Subscriber subscriberOne = new Subscriber("Ninja Cat", publisher);
            Subscriber subscriberTwo = new Subscriber("Evil Cat String", publisher);

            // Call the method that raises the event.
            publisher.PrintSomeText();
                        
            Console.WriteLine();
        }
    }
}
