using System;

class GravitationOnTheMoon
{
    /* Problem 2. Gravitation on the Moon
     * The gravitational field of the Moon is approximately 17% of that on the Earth.
     * Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
    */
    static void Main()
    {
        double earthWeight, moonWeight;
        Console.Write("Please enter your Weight = ");
        earthWeight = double.Parse(Console.ReadLine());

        moonWeight = earthWeight * 0.17;
        Console.WriteLine("Your weight at the Moon will be: {0}", moonWeight);
    }
}

