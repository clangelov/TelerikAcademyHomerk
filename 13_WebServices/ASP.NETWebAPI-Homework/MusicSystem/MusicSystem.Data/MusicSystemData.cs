namespace MusicSystem.Data
{
    using System;
    using System.Collections.Generic;
    using MusicSystem.Data.Repositories;
    using Models;

    public class MusicSystemData : IMusicSystemData
    {
        private IMusicSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public MusicSystemData()
            : this(new MusicSystemDbContext())
        {
        }

        public MusicSystemData(IMusicSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var typeOfModel = typeof(TEntity);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<TEntity>), this.context);
                this.repositories.Add(typeOfModel, newRepository);
            }

            return (IRepository<TEntity>)this.repositories[typeOfModel];
        }
    }
}
