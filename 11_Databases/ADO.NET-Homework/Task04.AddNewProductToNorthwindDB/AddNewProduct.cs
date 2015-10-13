namespace Task04.AddNewProductToNorthwindDB
{
    using System;
    using System.Data.SqlClient;

    public class AddNewProduct
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.;Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                var product = new Product
                {
                    ProductName = "White Stork Beer",
                    SupplierID = null,
                    CategoryID = 1,
                    UnitPrice = 3.50M,
                    Discontinued = false
                };

                InsertNewProduct(dbCon, product);                
            }
        }

        private static void InsertNewProduct(SqlConnection dbCon, Product product)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Products ([ProductName], [SupplierID], " +  
                "[CategoryID], [UnitPrice], [Discontinued]) " +
                " VALUES (@name, @supplierID, @categoryID, @price, @isDicontinued)", dbCon);

            insertCommand.Parameters.AddWithValue("@name", product.ProductName);
            insertCommand.Parameters.AddWithValue("@categoryID", product.CategoryID);
            insertCommand.Parameters.AddWithValue("@price", product.UnitPrice);
            insertCommand.Parameters.AddWithValue("@isDicontinued", product.Discontinued);

            SqlParameter sqlParameterSupplierID = new SqlParameter("@supplierID", product.SupplierID);
            if (product.SupplierID == null)
            {
                sqlParameterSupplierID.Value = DBNull.Value;
            }

            insertCommand.Parameters.Add(sqlParameterSupplierID);
            insertCommand.ExecuteNonQuery();
            var rows = insertCommand.ExecuteNonQuery();
            Console.WriteLine("Rows affected {0}", rows);
            Console.WriteLine("Inserting product {0} Finished", product.ProductName);
        }
    }
}
