namespace _01_03.StudentClass
{
    using System;
    class TestStudent
    {
        static void Main()
        {
            Student studentOne = new Student("Mike", "Fast", "Miller", 555777, "Palo Alto", "01777888999", "mikeFast@gmail.com", "First", University.UCLA, Faculty.Arts, Specialty.VisualArts);

            Student studentTwo = new Student("Andy", "Smart", "Johnson", 666777, "San Diego", "01555666888", "smarty@gmail.com", "First", University.UCLA, Faculty.Science, Specialty.ComputerScience);
            
            // Test ToString()
            Console.WriteLine("Some info about me: {0}\n", studentOne);

            //Test GetHashCode
            Console.WriteLine("First Student:{0}, Second Student:{1}\n", studentOne.GetHashCode()
                , studentTwo.GetHashCode());

            // Test Equal 
            Console.WriteLine("Are {0} and {1} Equal: {2}\n", studentOne.FirstName, studentTwo.FirstName
               , studentOne.Equals(studentTwo));

            // Test Clone
            var strudentClone = studentOne.Clone() as Student;
            Console.WriteLine("My name is {0} and my Clone name is {1}\n", studentOne.FirstName, strudentClone.FirstName);

            // Test CompareTo
            if (studentOne.CompareTo(strudentClone) == 0)
            {
                Console.WriteLine("Me and my Clone are equal\n");
            }
        }
    }
}
