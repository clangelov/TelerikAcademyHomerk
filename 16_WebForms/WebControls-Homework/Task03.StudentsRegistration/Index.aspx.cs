using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task03.StudentsRegistration
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.Name.Text = this.FirstName.Text + " " + this.LastName.Text;
            this.Number.Text = "Faculty number: " + this.FacultyNumber.Text;
            this.UniSpec.Text = "University " + this.University.SelectedValue + " | Speciality " + this.Speciality.SelectedValue;

            var selectedCourses = new List<string>();

            foreach (ListItem item in this.Courses.Items)
            {
                if (item.Selected)
                {
                    selectedCourses.Add(item.Value);
                }
            }

            this.SelectedCourses.Text = "Courses: " + string.Join(", ", selectedCourses);
            this.ResultDiv.Visible = true;
        }

        public IQueryable<string> GetUniversities()
        {
            return (new[] { "MIT", "UCLA", "Stanford", "San Diego", "Berkeley" }).AsQueryable();
        }

        public IQueryable<string> GetSpecialities()
        {
            return (new[] { "Econimics", "Computer Science", "Physics", "Engineering", "Art" }).AsQueryable();
        }

        public IQueryable<string> GetCourses()
        {
            return (new[] { "Movie Design", "Building Innovative Brands", "Change that has a Chance", "Creativity Rules", "Engineering Innovation", "Innovations in Education" }).AsQueryable();
        }
    }
}