namespace StudentsSystem.WebApi.Models
{
    using System;
    using StudentSystem.Models;

    public class TestDataModel
    {
        public static Func<Test, TestDataModel> FromDataToModel
        {
            get
            {
                return t => new TestDataModel()
                {
                    Course = t.Course.Name
                };
            }
        }

        public string Course { get; set; }

        public static Test FromModelToData(TestDataModel testDataModel, Course course)
        {
            return new Test()
            {
                Course = course,
                CourseId = course.Id
            };
        }
    }
}