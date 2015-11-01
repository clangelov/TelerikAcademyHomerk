namespace StudentsSystem.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using StudentSystem.Data;

    public class StudentController :BaseApiController
    {
        public StudentController(IStudentSystemData dataToUse)
           : base(dataToUse)
        {
        }

        public StudentController()
            : base(new StudentsSystemData())
        {
        }

        public IHttpActionResult Get()
        {
            var allStudents = this.Data.Students.All().Select(StudentDataModel.FromDataToModel);
            return this.Ok(allStudents);
        }

        public IHttpActionResult GetById(int Id)
        {
            var allStudents = this.Data
                .Students
                .SearchFor(s => s.StudentIdentification == Id)
                .Select(StudentDataModel.FromDataToModel);

            if (allStudents.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(allStudents);
        }

        public IHttpActionResult Post([FromBody] StudentDataModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var studentToAdd = StudentDataModel.FromModelToData(studentModel);
            this.Data.Students.Add(studentToAdd);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), studentToAdd);
        }

        public IHttpActionResult Put(int Id, [FromBody] StudentDataModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var studentById = this.Data.Students.SearchFor(s => s.StudentIdentification == Id).FirstOrDefault();

            if (studentById == null)
            {
                return this.NotFound();
            }

            studentById.FirstName = studentModel.FirstName;
            studentById.LastName = studentModel.LastName;

            studentById.AdditionalInformation.Email = string.IsNullOrEmpty(studentModel.Email) ? studentById.AdditionalInformation.Email : studentModel.Email;
            studentById.AdditionalInformation.Address = string.IsNullOrEmpty(studentModel.Address) ? studentById.AdditionalInformation.Address : studentModel.Address;

            this.Data.Students.Update(studentById);
            this.Data.SaveChanges();

            return this.Ok("Student was updated");
        }

        public IHttpActionResult Delete(int Id)
        {
            var studentById = this.Data.Students.SearchFor(s => s.StudentIdentification == Id).FirstOrDefault();

            if (studentById == null)
            {
                return this.NotFound();
            }

            this.Data.Students.Delete(studentById);
            this.Data.SaveChanges();

            return this.Ok("Student was deleted");
        }
    }
}