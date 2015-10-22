namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using StudentsSystem.Models;

    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext()
            :base("StudentsSystemDb")
        {          
        }
        
        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Student> Students { get; set; }
    }
}
