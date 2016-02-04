namespace Movies.Services.Data
{
    using System.Linq;
    using Contracts;
    using Movies.Data.Models;
    using Movies.Data.Repositories;

    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> movies;

        public MovieService(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> All()
        {
            return this.movies.All();
        }

        public Movie CreateMovie(string title, int year, string director, int MaleActorId, int FemaleActorId)
        {
            var movieToAdd = new Movie
            {
                Title = title,
                Year = year,
                Director = director,
                MaleActorId = MaleActorId,
                FemaleActorId = FemaleActorId
            };

            this.movies.Add(movieToAdd);
            this.movies.SaveChanges();

            return movieToAdd;
        }

        public void DeleteById(int id)
        {
            Movie itemToDelet = this.movies.GetById(id);

            if (itemToDelet != null)
            {
                this.movies.Delete(itemToDelet);
                this.movies.SaveChanges();
            }
        }

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void Update(Movie item)
        {
            this.movies.Update(item);
            this.movies.SaveChanges();
        }
    }
}
