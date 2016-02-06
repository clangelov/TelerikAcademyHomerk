namespace Twitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Twitter.Data.Models;

    public interface ITwitterDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
