namespace MusicSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MusicSystem.Models;

    public class AlbumDataModel
    {
        public static Func<Album, AlbumDataModel> FromDataToModel
        {
            get
            {
                return a => new AlbumDataModel()
                {
                    Title = a.Title,
                    Year = a.Year,
                    Producer = a.Producer,
                    Artists = a.Artists.Select(ar => ar.Name).ToArray(),
                    Songs = a.Songs.Select(s => s.Title).ToArray()
                };
            }
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public virtual IEnumerable<string> Artists { get; set; }

        public virtual IEnumerable<string> Songs { get; set; }

        public static Album FromModelToData(AlbumDataModel albumModel)
        {
            return new Album()
            {
                Title = albumModel.Title,
                Year = albumModel.Year,
                Producer = albumModel.Producer
            };
        }
    }
}