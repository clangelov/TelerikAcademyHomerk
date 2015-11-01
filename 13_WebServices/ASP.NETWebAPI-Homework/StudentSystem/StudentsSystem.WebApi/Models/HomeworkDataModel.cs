namespace StudentsSystem.WebApi.Models
{
    using System;
    using StudentSystem.Models;

    public class HomeworkDataModel
    {
        public static Func<Homework, HomeworkDataModel> FromDataToModel
        {
            get
            {
                return h => new HomeworkDataModel()
                {
                    FileUrl = h.FileUrl,
                    TimeSent =h.TimeSent,
                    Course = h.Course.Name
                };
            }
        }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public string Course { get; set; }

        public static Homework FromModelToData(HomeworkDataModel homeworkDataModel, Course course)
        {
            return new Homework()
            {
                FileUrl = homeworkDataModel.FileUrl,
                TimeSent = homeworkDataModel.TimeSent,
                CourseId = course.Id
            };
        }
    }
}