namespace Movies.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Models;

    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public MovieDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Actor> Actors { get; set; }

        public static MovieDbContext Create()
        {
            return new MovieDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
