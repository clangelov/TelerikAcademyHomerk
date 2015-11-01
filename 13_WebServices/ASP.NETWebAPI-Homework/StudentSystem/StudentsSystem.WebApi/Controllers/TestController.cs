namespace StudentsSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using StudentSystem.Data;

    public class TestController : BaseApiController
    {
        public TestController(IStudentSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public TestController()
            : base(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allTests = this.Data.Tests.All().Select(TestDataModel.FromDataToModel);
            return this.Ok(allTests);
        }

        public IHttpActionResult GetById(int Id)
        {
            var testById = this.Data.Tests.SearchFor(t => t.Id == Id).Select(TestDataModel.FromDataToModel);

            if (testById.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(testById);
        }

        public IHttpActionResult Post([FromBody] TestDataModel testModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.Data.Courses.SearchFor(c => c.Name == testModel.Course).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid course name");
            }

            var test = TestDataModel.FromModelToData(testModel, course);
            this.Data.Tests.Add(test);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), test);
        }

        public IHttpActionResult Put(int Id, [FromBody] TestDataModel testModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var testById = this.Data.Tests.SearchFor(t => t.Id == Id).FirstOrDefault();

            if (testById == null)
            {
                return this.NotFound();
            }

            var course = this.Data.Courses.SearchFor(c => c.Name == testModel.Course).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid course name");
            }

            testById.Course = course;
            testById.CourseId = course.Id;

            this.Data.Tests.Update(testById);
            this.Data.SaveChanges();

            return this.Ok("Test was updated");
        }

        public IHttpActionResult Delete(int Id)
        {
            var testById = this.Data.Tests.SearchFor(t => t.Id == Id).FirstOrDefault();

            if (testById == null)
            {
                return this.NotFound();
            }

            this.Data.Tests.Delete(testById);
            this.Data.SaveChanges();

            return this.Ok("Test was deleted");
        }
    }
}