namespace BugLogger.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        void Remove(object id);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
