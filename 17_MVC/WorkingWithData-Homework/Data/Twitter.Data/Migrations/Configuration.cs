namespace Twitter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using DataSeed;

    public sealed class Configuration : DbMigrationsConfiguration<TwitterDbContext>
    {
        public static Random Rand = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            new AdminSeeder().Seed(context);
            new TweetSeeder().Seed(context);
        }
    }
}
