namespace Movies.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MovieDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MovieDbContext context)
        {
            context.Actors.AddOrUpdate(a => a.Id,
               new Actor() { Id = 1, Name = "Jean Dujardin", Age = 44, Studio = "France", StudioAdress = "Paris Blvd" },
               new Actor() { Id = 2, Name = "Leonardo DiCaprio", Age = 41, Studio = "Hollywood", StudioAdress = "LA Sunset Blvd" },
               new Actor() { Id = 3, Name = "Keira Knightley", Age = 31, Studio = "Hollywood", StudioAdress = "LA Sunset Blvd" },
               new Actor() { Id = 4, Name = "Charlotte Le Bon", Age = 34, Studio = "France", StudioAdress = "Paris Blvd" });

            context.Movies.AddOrUpdate(m => m.Id,
             new Movie() { Id = 1, Title = "Mood Indigo", Year = 2013, Director = "Michel Gondry", MaleActorId = 1, FemaleActorId = 4 },
             new Movie() { Id = 2, Title = "A Dangerous Method", Year = 2011, Director = "Sabina Spielrein", MaleActorId = 1, FemaleActorId = 3 }
             );
        }
    }
}
