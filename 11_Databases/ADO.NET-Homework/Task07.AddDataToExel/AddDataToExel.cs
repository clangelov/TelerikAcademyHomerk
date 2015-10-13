namespace Task07.AddDataToExel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class AddDataToExel
    {
        public static void Main()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../table.xlsx;Extended Properties='Excel 12.0 xml;HDR=Yes';";

            OleDbConnection dbConn = new OleDbConnection(connectionString);

            using (dbConn)
            {
                dbConn.Open();
                var excelSchema = dbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                WritteToExel(dbConn, sheetName);
            }
        }

        private static void WritteToExel(OleDbConnection dbConn, string sheetName)
        {
            Console.WriteLine("Writting data...");
            var insertCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + "] ([Name], [Score]) VALUES (@name, @score)", dbConn);

            insertCommand.Parameters.AddWithValue("@name", "Maverick Sabre");
            insertCommand.Parameters.AddWithValue("@score", 7);

            insertCommand.ExecuteNonQuery();
            var rows = insertCommand.ExecuteNonQuery();
            Console.WriteLine("Rows affected {0}", rows);
        }
    }
}
