using System;
class PrimeNumberCheck
{
    /* Problem 8. Prime Number Check
     * Write an expression that checks if given positive integer number n (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1).
    */
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int input = int.Parse(Console.ReadLine());
        bool prime = true;

        if (input == 2 || input == 3 || 5 == input || 7 == input)
        {
            Console.WriteLine("The number is prime: {0}!", prime);
        }
        else
        {
            if (((input % 2) != 0) && ((input % 3) != 0) && ((input % 5) != 0) && ((input % 7) != 0))
            {
                Console.WriteLine("The number is prime: {0}!", prime);
            }
            else
            {
                Console.WriteLine("The number is prime: {0}!", !prime);
            }
        }
    }
}

