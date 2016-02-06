namespace Twitter.Data.DataSeed
{
    public interface IDataSeeder
    {
        void Seed(TwitterDbContext context);
    }
}
