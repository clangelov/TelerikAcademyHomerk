namespace MusicSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MusicSystem.Models;

    public class ArtistDataModel
    {
        public static Func<Artist, ArtistDataModel> FromDataToModel
        {
            get
            {
                return a => new ArtistDataModel()
                {
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth,
                    Albums = a.Albums.Select(al => al.Title).ToArray(),
                    Songs = a.Songs.Select(s => s.Title).ToArray()
                };
            }
        }

        public string Name { get; set; }
        
        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual IEnumerable<string> Albums { get; set; }

        public virtual IEnumerable<string> Songs { get; set; }

        public static Artist FromModelToData(ArtistDataModel artistModel)
        {
            return new Artist()
            {
                Name = artistModel.Name,
                Country = artistModel.Country,
                DateOfBirth = artistModel.DateOfBirth ?? null
            };
        }
    }
}