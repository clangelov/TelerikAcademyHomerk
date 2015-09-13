namespace WhiskeyFacotryMethodDemo
{
    using System;

    using WhiskeyFacotryMethodDemo.Manufactures;
    
    public class Client
    {    
        public static void Main()
        {
            GetDrinkFromDistilley(new EireOld());
            LineSeparator();

            GetDrinkFromDistilley(new NorthWildScotts());
            LineSeparator();

            GetDrinkFromDistilley(new TennesseeFinest());
            LineSeparator();
        }

        private static void GetDrinkFromDistilley(Distillery distillery)
        {
            var drink = distillery.MakeDrink();
            Console.WriteLine(drink.ToString());
        }

        private static void LineSeparator()
        {
            Console.WriteLine(new string('-', 60));
        }
    }
}
