namespace MusicSystem.Data
{
    using MusicSystem.Data.Repositories;
    using MusicSystem.Models;

    public interface IMusicSystemData
    {
        IRepository<Album> Albums { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
