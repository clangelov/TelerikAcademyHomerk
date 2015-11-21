namespace BugLogger.Services.Data.Tests.TestObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BugLogger.Data;

    public class InMemoryRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly IList<T> data;

        public InMemoryRepository()
        {
            this.data = new List<T>();
            this.AttachedEntities = new List<T>();
            this.DetachedEntities = new List<T>();
            this.UpdatedEntities = new List<T>();
        }

        public IList<T> AttachedEntities { get; private set; }

        public IList<T> DetachedEntities { get; private set; }

        public IList<T> UpdatedEntities { get; private set; }

        public bool IsDisposed { get; private set; }

        public int NumberOfSaves { get; private set; }

        public IQueryable<T> All()
        {
            return this.data.AsQueryable();
        }

        public T GetById(object id)
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No objects in database");
            }

            return this.data[0];
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.data.Where(conditions.Compile()).AsQueryable();
        }

        public void Add(T entity)
        {
            this.data.Add(entity);
        }

        public void Update(T entity)
        {
            this.UpdatedEntities.Add(entity);
        }

        public void Remove(object id)
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Nothing to delete");
            }

            this.data.Remove(this.data[0]);
        }

        public T Attach(T entity)
        {
            this.AttachedEntities.Add(entity);
            return entity;
        }

        public void Detach(T entity)
        {
            this.DetachedEntities.Add(entity);
        }

        public int SaveChanges()
        {
            this.NumberOfSaves++;
            return 1;
        }

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}
