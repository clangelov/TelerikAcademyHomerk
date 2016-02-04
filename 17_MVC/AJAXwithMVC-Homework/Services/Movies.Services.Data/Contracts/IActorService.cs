namespace Movies.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Movies.Data.Models;

    public interface IActorService
    {
        IQueryable<Actor> All();

        Actor CreateActor(string name, int age, string studio, string studioAdress);
        
        void DeleteById(int id);

        Actor GetById(int id);

        int GetByName(string name);

        void Update(Actor item);
    }
}
