namespace Task03.ImplementBiDictionary
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var multiDict = new MyBiDictionary<string, int, string>();

            multiDict.Add("grime", 1, "Tinie Tempah");
            multiDict.Add("grime", 1, "Stormzy");
            multiDict.Add("bbc", 3, "Charlie Sloth");
            multiDict.Add("grime", 1, "Skepta");
            multiDict.Add("bbc", 3, "MistaJam");
            multiDict.Add("uk", 2, "Meridian Dan");

            Console.WriteLine("By first key grime {0}", multiDict.GetByFirstKey("grime"));

            Console.WriteLine("By second key 3 {0}", multiDict.GetBySecondKey(3));

            Console.WriteLine("By both keys uk and 2 {0}", multiDict.GetByBoth("uk", 2));
        }
    }
}
