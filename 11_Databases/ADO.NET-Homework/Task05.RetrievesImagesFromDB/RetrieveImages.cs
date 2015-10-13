namespace Task05.RetrievesImagesFromDB
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class RetrieveImages
    {
        private const string StoreLocation = @"../../Pictures";

        public static void Main()
        {
            ExtractImageFromDB();
        }

        private static void ExtractImageFromDB()
        {
            SqlConnection dbConn = new SqlConnection("Server=.;Database=Northwind; Integrated Security=true");
            dbConn.Open();

            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbConn);                
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    var counter = 1;
                    while (reader.Read())
                    {
                        var imageByteArray = (byte[])reader["Picture"];
                        string name = (string)reader["CategoryName"];                        
                        using (var fs = File.OpenWrite("file" + counter + ".jpg"))
                        using (var stream = reader.GetStream(1))
                        {
                            stream.Seek(78, SeekOrigin.Begin);
                            stream.CopyTo(fs);
                            counter++;
                        }
                    }

                    Console.WriteLine("Pictures are saved to \"\\bin\\Debug\" directory");
                }
            }            
        }        
    }
}
