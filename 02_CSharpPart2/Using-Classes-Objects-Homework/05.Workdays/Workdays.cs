/*
 * Problem 5. Workdays
 * Write a method that calculates the number of workdays between today and given date, passed as parameter.
 * Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
*/
using System;
using System.Globalization;
using System.Threading;

class Workdays
{
    static DateTime[] Holidays = {
            new DateTime(2015,01,01),
            new DateTime(2015,03,03),
            new DateTime(2015,04,10),
            new DateTime(2015,04,13),
            new DateTime(2015,05,01),
            new DateTime(2015,05,06),
            new DateTime(2015,05,24),
            new DateTime(2015,09,06),
            new DateTime(2015,09,22),
            new DateTime(2015,12,24),
            new DateTime(2015,12,25),
                                 };

    static int WorkingDays (DateTime dateNow, DateTime endDate)
    {
        // Calculating the difference in days between the two dates and thi will give us 
        // how many times to run the for cycle
        int daysLenght = Math.Abs((dateNow-endDate).Days);
        
        // Assigning this value to the counter
        int counter = daysLenght;

        for (int i = 0; i < daysLenght; i++)
		{
            // every time we add 1 day
			dateNow = dateNow.AddDays(1);

            // checking if this date is Saturday or Sunday and substract it
            if (dateNow.DayOfWeek == DayOfWeek.Saturday || dateNow.DayOfWeek == DayOfWeek.Sunday)
	        {
		    counter--;
	        }
            
            // going thru all Holidays and if there is a match -> substracting one day
            for (int days = 0; days < Holidays.Length; days++)
			{
			    if (dateNow.CompareTo(Holidays[days]) == 0)
	            {
                    counter--;		 
	            } 
			}
		}

        return counter; // final result
    }
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        DateTime dateNow = DateTime.Now;

        Console.WriteLine("Enter day in format YEAR/MONTH/DAY:");
        string[] dateArr = Console.ReadLine().Split('/');

        int year = int.Parse(dateArr[0]);
        int days = int.Parse(dateArr[2]);
        int month = int.Parse(dateArr[1]);

        DateTime endDate = new DateTime(year, month, days);

        if (endDate < dateNow || endDate > new DateTime(2015, 12, 31))
        {
            Console.WriteLine("InvalidInput");
            return;
        }

        Console.WriteLine("There are {0} workings days between {1:yyyy/M/d} and {2:yyyy/M/d}",
        WorkingDays(dateNow, endDate), dateNow, endDate);
    }
}

