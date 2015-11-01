namespace StudentsSystem.WebApi.Models
{
    using System;
    using StudentSystem.Models;

    public class StudentDataModel
    {
        public static Func<Student, StudentDataModel> FromDataToModel
        {
            get
            {
                return s => new StudentDataModel()
                {
                    Address = s.AdditionalInformation.Address,
                    Email = s.AdditionalInformation.Email,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Level = s.Level
                };
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public static Student FromModelToData(StudentDataModel studentDataModel)
        {
            return new Student()
            {
                AdditionalInformation = new StudentInfo()
                {
                    Address = studentDataModel.Address,
                    Email = studentDataModel.Email
                },
                FirstName = studentDataModel.FirstName,
                LastName = studentDataModel.LastName,
                Level = studentDataModel.Level
            };
        }
    }
}