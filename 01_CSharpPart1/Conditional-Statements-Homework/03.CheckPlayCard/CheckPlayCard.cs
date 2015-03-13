using System;
class CheckPlayCard
{
    /* Problem 3. Check for a Play Card
     * Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise. 
    */
    static void Main()
    {
        Console.Write("Please enter card = ");
        string card = Console.ReadLine();

        // Creating an Array with all objects
        string[] cardArray = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        if (Array.IndexOf(cardArray, card) >= 0)
        //  Searches for the specified object and returns the index of its first occurrence,
        //  so if the returned value is >= 0 we have a match! 
        {
            Console.WriteLine("Valid Card = Yes");
        }
        else
        {
            Console.WriteLine("Valid Card = No");
        }
    }
}

