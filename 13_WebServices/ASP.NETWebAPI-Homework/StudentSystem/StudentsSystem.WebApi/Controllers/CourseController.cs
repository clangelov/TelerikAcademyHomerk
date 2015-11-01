namespace StudentsSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using StudentSystem.Data;

    public class CourseController : BaseApiController
    {
        public CourseController(IStudentSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public CourseController()
            : base(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allCourses = this.Data.Courses.All().Select(CourseDataModel.FromDataToModel);
            return this.Ok(allCourses);
        }

        public IHttpActionResult GetById(string Id)
        {
            var allCourses = this.Data
                .Courses
                .SearchFor(c => c.Id.ToString() == Id)
                .Select(CourseDataModel.FromDataToModel);

            if (allCourses.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(allCourses);
        }

        public IHttpActionResult Post([FromBody] CourseDataModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var courseToAdd = CourseDataModel.FromModelToData(courseModel);
            this.Data.Courses.Add(courseToAdd);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), courseToAdd);
        }

        public IHttpActionResult Put(string Id, [FromBody] CourseDataModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var courseById = this.Data.Courses.SearchFor(c => c.Id.ToString() == Id).FirstOrDefault();

            if (courseById == null)
            {
                return this.NotFound();
            }

            courseById.Name = courseModel.Name;
            courseById.Description = courseModel.Description;

            this.Data.Courses.Update(courseById);
            this.Data.SaveChanges();

            return this.Ok("Course was updated");
        }

        public IHttpActionResult Delete(string Id)
        {
            var courseById = this.Data.Courses.SearchFor(c => c.Id.ToString() == Id).FirstOrDefault();

            if (courseById == null)
            {
                return this.NotFound();
            }

            this.Data.Courses.Delete(courseById);
            this.Data.SaveChanges();

            return this.Ok("Course was deleted");
        }
    }
}