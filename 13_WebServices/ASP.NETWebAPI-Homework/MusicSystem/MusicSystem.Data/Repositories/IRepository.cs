namespace MusicSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> conditions);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Detach(TEntity entity);
    }
}
