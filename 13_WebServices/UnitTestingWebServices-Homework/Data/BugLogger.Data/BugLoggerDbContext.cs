namespace BugLogger.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class BugLoggerDbContext : DbContext, IBugLoggerDbContext
    {
        public BugLoggerDbContext()
            : base("BugLoggerDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public static BugLoggerDbContext Create()
        {
            return new BugLoggerDbContext();
        }
    }
}
