namespace StudentsSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using StudentSystem.Data;

    public class HomeworkController : BaseApiController
    {
        public HomeworkController(IStudentSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public HomeworkController()
            : base(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allHomewroks = this.Data.Homeworks.All().Select(HomeworkDataModel.FromDataToModel);
            return this.Ok(allHomewroks);
        }

        public IHttpActionResult GetById(int Id)
        {
            var homeworkById = this.Data.Homeworks.SearchFor(h => h.Id == Id).Select(HomeworkDataModel.FromDataToModel);

            if (homeworkById.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(homeworkById);
        }

        public IHttpActionResult Post([FromBody] HomeworkDataModel homeworkModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.Data.Courses.SearchFor(c => c.Name == homeworkModel.Course).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid course name");
            }

            var homeworkToAdd = HomeworkDataModel.FromModelToData(homeworkModel, course);
            this.Data.Homeworks.Add(homeworkToAdd);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), homeworkToAdd);
        }

        public IHttpActionResult Put(int Id, [FromBody] HomeworkDataModel homeworkModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var homeworkById = this.Data.Homeworks.SearchFor(h => h.Id == Id).FirstOrDefault();

            if (homeworkById == null)
            {
                return this.NotFound();
            }

            var course = this.Data.Courses.SearchFor(c => c.Name == homeworkModel.Course).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid course name");
            }

            homeworkById.Course = course;
            homeworkById.CourseId = course.Id;
            homeworkById.FileUrl = homeworkModel.FileUrl;
            homeworkById.TimeSent = homeworkModel.TimeSent;

            this.Data.Homeworks.Update(homeworkById);
            this.Data.SaveChanges();

            return this.Ok("Homework was updated");
        }

        public IHttpActionResult Delete(int Id)
        {
            var homeworkById = this.Data.Homeworks.SearchFor(h => h.Id == Id).FirstOrDefault();

            if (homeworkById == null)
            {
                return this.NotFound();
            }

            this.Data.Homeworks.Delete(homeworkById);
            this.Data.SaveChanges();

            return this.Ok("Homework was deleted");
        }
    }
}