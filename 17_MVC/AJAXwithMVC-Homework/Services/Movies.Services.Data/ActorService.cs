namespace Movies.Services.Data
{
    using System;
    using System.Linq;
    using Movies.Data.Models;
    using Movies.Data.Repositories;
    using Movies.Services.Data.Contracts;

    public class ActorService : IActorService
    {
        private readonly IRepository<Actor> actors;

        public ActorService(IRepository<Actor> actors)
        {
            this.actors = actors;
        }

        public IQueryable<Actor> All()
        {
            return this.actors.All();
        }

        public Actor CreateActor(string name, int age, string studio, string studioAdress)
        {
            var actorToAdd = new Actor
            {
                Name = name,
                Age = age,
                Studio = studio,
                StudioAdress = studioAdress
            };

            this.actors.Add(actorToAdd);
            this.actors.SaveChanges();

            return actorToAdd;
        }

        public void DeleteById(int id)
        {
            Actor itemToDelet = this.actors.GetById(id);

            if (itemToDelet != null)
            {
                this.actors.Delete(itemToDelet);
                this.actors.SaveChanges();
            }
        }

        public Actor GetById(int id)
        {
            return this.actors.GetById(id);
        }

        public int GetByName(string name)
        {
            if (this.actors.All().Where(a => a.Name.Contains(name)).Any())
            {
                return this.actors.All().Where(a => a.Name.Contains(name)).Select(x => x.Id).First();
            }
            else
            {
                return -1;
            }
        }

        public void Update(Actor item)
        {
            this.actors.Update(item);
            this.actors.SaveChanges();
        }
    }
}
