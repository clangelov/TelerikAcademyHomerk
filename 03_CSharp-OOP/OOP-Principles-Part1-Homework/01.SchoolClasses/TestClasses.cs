/*
 * Problem 1. School classes
 * We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
 * Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
*/
namespace _01.SchoolClasses
{
    using System;
    using System.Collections.Generic;

    class TestClasses
    {
        static void Main()
        {
            Disciplines[] subjectsArr = new Disciplines[]{
                new Disciplines("Sport", 1, 2),
                new Disciplines("Science", 4, 2),
                new Disciplines("Italian", 3, 3),
            };

            Student[] arrStudents = new Student[]{
                new Student("Andy" , 1),
                new Student("Mike" , 3),
                new Student("William" , 7),
                new Student("Maria" , 16),
                new Student("Sofia" , 17),
            };

            Teacher[] setOfteachers = new Teacher[]{
                new Teacher("Cassius Clay", new List<Disciplines>{subjectsArr[0], subjectsArr[1]}),
                new Teacher("Bar Rafaeli", new List<Disciplines>{subjectsArr[2], subjectsArr[1]}), 
            };

            // Creating a new class
            Classes wildlings = new Classes("Wildlings");

            // Adding students
            wildlings.AddManyStudentToClass(arrStudents[0], arrStudents[1], arrStudents[2]
                , arrStudents[3], arrStudents[4]);

            // Adding teachers
            wildlings.AddTeacherToClass(setOfteachers[0]);
            wildlings.AddTeacherToClass(setOfteachers[1]);

            // Adding disciplines
            wildlings.AddDisciplineToClass(subjectsArr[0]);
            wildlings.AddDisciplineToClass(subjectsArr[1]);
            wildlings.AddDisciplineToClass(subjectsArr[2]);

            // Adding Comments
            arrStudents[0].Comment = "Misses classes quite often";
            setOfteachers[1].Comment = "Best teacher in school";
            wildlings.Comment = "Very poor discipline and marks";

            // To string Method + Comments
            Console.WriteLine("ToString() student -> {0};\nComment: {1}\n"
                , arrStudents[0], arrStudents[0].Comment);
            Console.WriteLine("ToString() teacher -> {0};\nComment: {1}\n"
                , setOfteachers[1], setOfteachers[1].Comment);
            Console.WriteLine("ToString() class -> {0};\nComment: {1}\n"
                , wildlings, wildlings.Comment);

        }
    }
}
