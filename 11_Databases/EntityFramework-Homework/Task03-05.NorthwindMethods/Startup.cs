namespace Task03_05.NorthwindMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Task01.CreateDbContextForNorthwind;

    public class Startup
    {
        public static void Main()
        {
            // Task 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            MakeASeparationLine(" Task 03 ");

            FindCustomersWithOrdersByCountryAndYear("Canada", 1997);

            // Task 04. Implement previous by using native SQL query and executing it through the DbContext.
            MakeASeparationLine(" Task 04 ");

            FindCustomersWithNativeQUery("Canada", 1997);

            // Task 05. Write a method that finds all the sales by specified region and period (start / end dates).
            MakeASeparationLine(" Task 05 ");

            FindAllOrders("SP", new DateTime(1998, 01, 01), DateTime.Now);
        }

        public static void FindCustomersWithOrdersByCountryAndYear(string country, int year)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var customers = northwindEntities.Orders
                    .Where(o => o.ShipCountry == country && o.ShippedDate.Value.Year == year)
                    .Select(c => c.Customer.ContactName)
                    .Distinct()
                    .ToList();

                DisplayResultsFromQuery(customers, country, year);
            }
        }

        public static void FindCustomersWithNativeQUery(string country, int year)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                string nativeSqlQuery =
                        "SELECT DISTINCT c.ContactName AS [ContactName]" +
                        "FROM Orders o " +
                        "JOIN Customers c ON c.CustomerID = o.CustomerID " +
                        "WHERE o.ShipCountry = '" + country + "'" + 
                        " AND DATEPART(YEAR, o.ShippedDate) = " + year;

                var customers = northwindEntities.Database.SqlQuery<string>(nativeSqlQuery).ToList();

                DisplayResultsFromQuery(customers, country, year);
            }
        }

        public static void FindAllOrders(string region, DateTime startDate, DateTime endDate)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var orders = northwindEntities.Orders
                    .Where(o => o.ShipRegion == region && o.ShippedDate > startDate && o.ShippedDate < endDate)
                    .OrderBy(sd => sd.ShippedDate)
                    .ToList();

                var counter = 1;
                foreach (var item in orders)
                {
                    Console.WriteLine("{0}. Shipped to {1} in region {2} at {3:d.MM.yy}", counter, item.ShipName, item.ShipRegion, item.ShippedDate);
                    counter++;
                }
            }
        }

        private static void MakeASeparationLine(string task)
        {
            Console.WriteLine(new string('=', 25) + task + new string('=', 25));
        }

        private static void DisplayResultsFromQuery(List<string> customers, string country, int year)
        {
            var counter = 1;
            foreach (var item in customers)
            {
                Console.WriteLine("{0}. {1} made a order to {2} in {3}", counter, item, country, year);
                counter++;
            }
        }
    }
}
