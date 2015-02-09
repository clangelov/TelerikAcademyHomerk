using System;

class FibonacciNumbers
{
    /* Problem 10. Fibonacci Numbers
     * Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
    */
    static void Main()
    {
        Console.Write("n: ");
        int number = int.Parse(Console.ReadLine());

        int firstFibonacci = 0;
        int secondFibonacci = 1;
        int nFibonacci;

        if (number >= 3)
        {
            Console.Write("{0}, {1}", firstFibonacci, secondFibonacci);
            
            for (int i = 2; i < number; i++)
            {
                nFibonacci = firstFibonacci;
                firstFibonacci = secondFibonacci;
                secondFibonacci = nFibonacci + firstFibonacci;
                Console.Write(", {0}", secondFibonacci);
            }
            Console.Write("."); // This will end the loop with a “.”
            Console.WriteLine();
        }
        
        else if (number == 2)
        {
            Console.WriteLine("{0}, {1}.", firstFibonacci, secondFibonacci);
        }
        
        else if (number == 1)
        {
            Console.WriteLine("{0}.", firstFibonacci);
        }
    }
}

