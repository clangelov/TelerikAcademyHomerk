namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models;

    public class AlbumController : BaseApiController
    {
        private const string BadRequestMessage = "Album with such Id does not exist";

        public AlbumController(IMusicSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public AlbumController()
            : base(new MusicSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allAlbums = this.Data.Albums.All().Select(AlbumDataModel.FromDataToModel);
            return this.Ok(allAlbums);
        }

        public IHttpActionResult GetById(int id)
        {
            var albumById = this.Data.Albums.SearchFor(t => t.Id == id).Select(AlbumDataModel.FromDataToModel);

            if (albumById.Count() == 0)
            {
                return this.BadRequest(BadRequestMessage);
            }

            return this.Ok(albumById);
        }

        public IHttpActionResult Post([FromBody] AlbumDataModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumToAdd = AlbumDataModel.FromModelToData(albumModel);
            this.Data.Albums.Add(albumToAdd);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), albumToAdd);
        }

        public IHttpActionResult Put(int id, [FromBody] AlbumDataModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumById = this.Data.Albums.SearchFor(t => t.Id == id).FirstOrDefault();

            if (albumById == null)
            {
                return this.BadRequest(BadRequestMessage);
            }

            albumById.Title = albumModel.Title;
            albumById.Year = albumModel.Year;
            albumById.Producer = albumModel.Producer;

            this.Data.Albums.Update(albumById);
            this.Data.SaveChanges();

            return this.Ok("Album was updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var albumById = this.Data.Albums.SearchFor(t => t.Id == id).FirstOrDefault();

            if (albumById == null)
            {
                return this.BadRequest(BadRequestMessage);
            }

            this.Data.Albums.Remove(albumById);
            this.Data.SaveChanges();

            return this.Ok("Album was deleted");
        }
    }
}