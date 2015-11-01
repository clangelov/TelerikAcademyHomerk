namespace StudentsSystem.WebApi.Controllers
{
    using System.Web.Http;
    using StudentSystem.Data;

    public class BaseApiController : ApiController
    {
        private IStudentSystemData data;

        public BaseApiController(IStudentSystemData dataToUse)
        {
            this.data = dataToUse;
        }

        protected IStudentSystemData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}