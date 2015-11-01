namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models;

    public class ArtistController : BaseApiController
    {
        private const string BadRequestMessage = "Artist with such Id does not exist";

        public ArtistController(IMusicSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public ArtistController()
            : base(new MusicSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allArtists = this.Data.Artists.All().Select(ArtistDataModel.FromDataToModel);
            return this.Ok(allArtists);
        }

        public IHttpActionResult GetById(int id)
        {
            var artistById = this.Data.Artists.SearchFor(t => t.Id == id).Select(ArtistDataModel.FromDataToModel);

            if (artistById.Count() == 0)
            {
                return this.BadRequest(BadRequestMessage);
            }

            return this.Ok(artistById);
        }

        public IHttpActionResult Post([FromBody] ArtistDataModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artistToAdd = ArtistDataModel.FromModelToData(artistModel);
            this.Data.Artists.Add(artistToAdd);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), artistToAdd);
        }

        public IHttpActionResult Put(int id, [FromBody] ArtistDataModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artistById = this.Data.Artists.SearchFor(t => t.Id == id).FirstOrDefault();

            if (artistById == null)
            {
                return this.BadRequest(BadRequestMessage);
            }

            artistById.Name = artistModel.Name;
            artistById.Country = artistModel.Country;
            artistById.DateOfBirth = artistModel.DateOfBirth;

            this.Data.Artists.Update(artistById);
            this.Data.SaveChanges();

            return this.Ok("Artist was updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var artistById = this.Data.Artists.SearchFor(t => t.Id == id).FirstOrDefault();

            if (artistById == null)
            {
                return this.BadRequest(BadRequestMessage);
            }

            this.Data.Artists.Remove(artistById);
            this.Data.SaveChanges();

            return this.Ok("Artist was deleted");
        }
    }
}