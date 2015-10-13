namespace Task06.ReadFromExcel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class ReadFromExcel
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
                Console.WriteLine(sheetName);

                ReadExcelData(dbConn, sheetName);
            }
        }

        private static void ReadExcelData(OleDbConnection dbConn, string sheetName)
        {
            Console.WriteLine("Reading data...");
            var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", dbConn);

            using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
            {
                DataSet dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet);

                using (var reader = dataSet.CreateDataReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} has a score of {1}", reader["Name"], reader["Score"]);
                    }
                }
            }
        }
    }
}
