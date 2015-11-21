namespace BugLogger.Api
{
    using Data;
    using System.Data.Entity;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
            BugLoggerDbContext.Create().Database.Initialize(true);
        }
    }
}