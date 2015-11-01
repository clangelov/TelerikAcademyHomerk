namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models;

    public class SongController : BaseApiController
    {
        private const string BadRequestMessage = "Song with such Id does not exist";

        public SongController(IMusicSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public SongController()
            : base(new MusicSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allSongs = this.Data.Songs.All().Select(SongDataModel.FromDataToModel);
            return this.Ok(allSongs);
        }

        public IHttpActionResult GetById(int id)
        {
            var songById = this.Data.Songs.SearchFor(s => s.Id == id).Select(SongDataModel.FromDataToModel);

            if (songById.Count() == 0)
            {
                return this.BadRequest(BadRequestMessage);
            }

            return this.Ok(songById);
        }

        public IHttpActionResult Post([FromBody] SongDataModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = this.Data.Artists.SearchFor(a => a.Name == songModel.Artist).FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Invalid artist name");
            }

            var album = this.Data.Albums.SearchFor(a => a.Title == songModel.Album).FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Invalid album title");
            }

            var songToAdd = SongDataModel.FromModelToData(songModel, artist, album);
            this.Data.Songs.Add(songToAdd);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), songToAdd);
        }

        public IHttpActionResult Put(int id, [FromBody] SongDataModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var songById = this.Data.Songs.SearchFor(s => s.Id == id).FirstOrDefault();

            if (songById == null)
            {
                return this.BadRequest(BadRequestMessage);
            }

            songById.Title = songModel.Title;
            songById.Year = songModel.Year;
            songById.Genre = songModel.Genre;

            this.Data.Songs.Update(songById);
            this.Data.SaveChanges();

            return this.Ok("Song was updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var songById = this.Data.Songs.SearchFor(t => t.Id == id).FirstOrDefault();

            if (songById == null)
            {
                return this.BadRequest(BadRequestMessage);
            }

            this.Data.Songs.Remove(songById);
            this.Data.SaveChanges();

            return this.Ok("Song was deleted");
        }
    }
}