namespace MusicSystem.Services.Models
{
    using System;
    using MusicSystem.Models;

    public class SongDataModel
    {
        public static Func<Song, SongDataModel> FromDataToModel
        {
            get
            {
                return s => new SongDataModel()
                {
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                    Artist = s.Artist.Name,
                    Album = s.Album.Title
                };
            }
        }

        public string Title { get; set; }
   
        public int Year { get; set; }

        public string Genre { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public static Song FromModelToData(SongDataModel songModel, Artist artist, Album album)
        {
            return new Song()
            {
                Title = songModel.Title,
                Year = songModel.Year,
                Genre = songModel.Genre,
                ArtistId = artist.Id,
                AlbumId = album.Id
            };
        }
    }
}