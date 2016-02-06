namespace Twitter.MVC
{   
    using System.Data.Entity;
    using Twitter.Data;
    using Twitter.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
            TwitterDbContext.Create().Database.Initialize(true);
        }
    }
}