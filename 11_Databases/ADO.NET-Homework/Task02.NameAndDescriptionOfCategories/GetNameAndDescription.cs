namespace Task02.NameAndDescriptionOfCategories
{
    using System;
    using System.Data.SqlClient;

    public class GetNameAndDescription
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.;Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand categoriesInfo = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);      

                Console.WriteLine("Categories and their description in NorthwindDB");

                var reader = categoriesInfo.ExecuteReader();

                using (reader)
                {
                    int counter = 1;
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0}. {1} -> {2}", counter, categoryName, description);
                        counter++;
                    }
                }
            }
        }
    }
}
