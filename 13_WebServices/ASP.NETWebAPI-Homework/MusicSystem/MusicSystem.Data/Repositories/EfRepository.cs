namespace MusicSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMusicSystemDbContext context;
        private IDbSet<TEntity> set;

        public EfRepository()
            :this (new MusicSystemDbContext())
        {
        }


        public EfRepository(IMusicSystemDbContext context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public IQueryable<TEntity> All()
        {
            return this.set.AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Update(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Detach(TEntity entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
