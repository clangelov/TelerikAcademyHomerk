namespace Task01.RetrieveCategoriesCount
{
    using System;
    using System.Data.SqlClient;

    public class CategoriesCount
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.;Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);

                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} In Northwind DB.", categoriesCount);
            }
        }
    }
}
