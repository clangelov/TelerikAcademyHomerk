/*
 * Problem 12. Call history test
 * MobilePhone is Class Libary and it can be accessed via its namespace
 * (Add References -> Solution -> Project -> MobilePhone)
*/
namespace GSMCallTest
{
    using System;
    using System.Linq;
    using MobilePhone;
    class GSMCallHistoryTest
    {
        private static Random rnd = new Random();
        static void Main()
        {
            // Create an instance of the GSM class.
            var testPhone = GSM.IPhone_6;

            // Add few calls
            testPhone.AddCall(new Calls("882115161", rnd.Next(20, 200)));
            testPhone.AddCall(new Calls("872117772", rnd.Next(20, 200)));
            testPhone.AddCall(new Calls("882684167", rnd.Next(20, 200)));
            testPhone.AddCall(new Calls("882113150", rnd.Next(20, 200)));
            testPhone.AddCall(new Calls("893651313", rnd.Next(20, 200)));

            // Display the information about the calls.
            foreach (var call in testPhone.CallHistory)
            {
                Console.WriteLine(call.ToString());
            }
            Console.WriteLine();

            // Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            Console.WriteLine("The total cost of your conversations is {0:C}\n", testPhone.PriceOfCall());

            // Remove the longest call from the history and calculate the total price again.

            Calls longest = testPhone.CallHistory
                .OrderByDescending(x => x.CallDuration) // Puting on first place the Call with longest duration
                .FirstOrDefault(); // Taking the first element

            testPhone.RemoveCall(longest);

            Console.WriteLine("The total cost without your longest conversation would be {0:C}\n"
                ,testPhone.PriceOfCall());

            // Finally clear the call history and print it.
            testPhone.ClearCallHistory();
            Console.WriteLine("Total number of Calls in Call History {0}\n", testPhone.CallHistory.Count);
        }
    }
}
