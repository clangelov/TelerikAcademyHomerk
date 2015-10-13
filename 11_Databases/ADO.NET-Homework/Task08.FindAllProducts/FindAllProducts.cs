namespace Task08.FindAllProducts
{
    using System;
    using System.Data.SqlClient;

    public class FindAllProducts
    {
        public static void Main()
        {
            Console.Write("Please enter the product for which are you looking: ");
            string clientInput = Console.ReadLine();
            clientInput = AddedEscapeSymbols(clientInput);
            SqlConnection dbCon = new SqlConnection("Server=.;Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE '%" + clientInput + "%'  ESCAPE '#'", dbCon);

                var reader = cmdCount.ExecuteReader();

                using (reader)
                {
                    int counter = 1;
                    Console.WriteLine("Listing products...");
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0}. {1}", counter, productName);
                        counter++;
                    }
                }
            }
        }

        private static string AddedEscapeSymbols(string clientInput)
        {
            clientInput = clientInput
                 .Replace("%", "#%")
                 .Replace("'", "#'")
                 .Replace("\"", "#\"")
                 .Replace("_", "#_")
                 .ToLower();

            return clientInput;
        }
    }
}
