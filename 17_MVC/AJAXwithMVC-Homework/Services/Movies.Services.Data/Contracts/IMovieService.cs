namespace Movies.Services.Data.Contracts
{
    using System.Linq;
    using Movies.Data.Models;

    public interface IMovieService
    {
        IQueryable<Movie> All();

        Movie CreateMovie(string title, int year, string director, int MaleActorId, int FemaleActorId);

        void DeleteById(int id);

        Movie GetById(int id);

        void Update(Movie item);
    }
}
