using System;

class DivideBy7And5
{
    /* Problem 3. Divide by 7 and 5
     * Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.
    */
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        bool result = (number % 5 == 0) && (number % 7 == 0) && (number != 0);
        Console.WriteLine("{0} can be divided by 5 and 7: {1}!", number, result);
    }
}

