namespace Movies.MVC
{
    using System.Data.Entity;
    using Movies.Data;
    using Movies.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieDbContext, Configuration>());
            MovieDbContext.Create().Database.Initialize(true);
        }
    }
}