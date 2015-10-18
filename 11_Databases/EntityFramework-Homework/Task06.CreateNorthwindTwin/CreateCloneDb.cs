namespace Task06.CreateNorthwindTwin
{
    using System;

    using Task01.CreateDbContextForNorthwind;

    public class CreateCloneDb
    {
        public static void Main()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                // To solve this task you need to change in the app.config file the connection string to:
                // initial catalog=NorthwindTwin
                var result = northwindEntities.Database.CreateIfNotExists();

                Console.WriteLine("Database NorthWindTwin is created: {0}", result ? "YES!" : "NO!");
            }
        }
    }
}
