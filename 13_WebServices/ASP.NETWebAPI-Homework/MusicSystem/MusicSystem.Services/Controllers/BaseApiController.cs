namespace MusicSystem.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        private IMusicSystemData data;

        public BaseApiController(IMusicSystemData dataToUse)
        {
            this.data = dataToUse;
        }

        protected IMusicSystemData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}