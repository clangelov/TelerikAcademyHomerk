/* 
 * Problem 7. GSM test
 * Write a class GSMTest to test the GSM class
 * MobilePhone is Class Libary and it can be accessed via its namespace
 * (Add References -> Solution -> Project -> MobilePhone)
*/
namespace GSMTest
{
    using System;
    using System.Linq;
    using MobilePhone;    
    class GSMTest
    {
        // setting some data, to random genarate GSMs, feel free to Add some more
        static Random pickRnd = new Random();

        static string[] company = new[] { "Samsung", "HTC", "Xiomi", "Sony" };

        static string[] owner = new[] { "Andy", "David", "Sam", "John", "Ben" };

        static Display[] displays = new[]{
                new Display(),
                new Display(3, 256000, Display.DisplayType.TFT),
                new Display(6, 320000000, Display.DisplayType.OLED)};

        static Battery[] batteries = new[]{
                new Battery(),
                new Battery(2, 20, BatteryType.NiMH),
                new Battery(30, 300, BatteryType.LiPoll)};
        static void Main()
        {
            // Array of 5 GSMs
            GSM[] testPhones = new GSM[5];

            // Random generated phones, based on a given pre-set of data 
            for (int i = 0; i < 5; i++)
            {
                testPhones[i] = new GSM(company[pickRnd.Next(0, company.Length)],
                    "Model S" + (i + 1), owner[pickRnd.Next(0, owner.Length)],
                    300 + (i * 50), displays[pickRnd.Next(0, displays.Length)],
                    batteries[pickRnd.Next(0, batteries.Length)]);
            }

            // Displaying some information about the phones
            foreach (var phone in testPhones)
            {
                Console.WriteLine("{0} bought a {1} {2} for {3:C}", phone.Owner, phone.Manufacturer, phone.Model, phone.Price);
            }

            Console.WriteLine();

            // sorting the  array by the size of the displays and then by the longest possible hours of talk
            // and finally printing the result

            var sorted = testPhones.OrderByDescending(x => x.Display.DisplaySize)
                .ThenByDescending(y => y.Battery.HoursTalk);

            foreach (var phone in sorted)
            {
                Console.WriteLine("{0} has display of {1}\" and can chat for {2} hours on his {3}"
                    , phone.Owner, phone.Display.DisplaySize, phone.Battery.HoursTalk, phone.Manufacturer);
            }

            // crating Iphone6 from Problem 6 
            var testIphone6 = GSM.IPhone_6;

            // printign the full information for Iphone6
            Console.WriteLine(GSM.FullPhoneInfo(testIphone6));
        }
    }
}
