// Write a program that reads N integers from the console and reverses them using a stack.
//  - Use the Stack<int> class.
namespace Task02.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToArray();

            var stackWithNumbers = new Stack<int>(array);

            Console.WriteLine("Reversed: {0}", string.Join(", ", stackWithNumbers));
        }
    }
}