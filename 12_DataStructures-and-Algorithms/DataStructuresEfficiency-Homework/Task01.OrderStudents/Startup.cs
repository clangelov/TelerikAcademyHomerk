namespace Task01.OrderStudents
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            SortedDictionary<string, SortedSet<Student>> allStudents = ReadDataFromFile();

            PrintResultToConsole(allStudents);
        }

        private static void PrintResultToConsole(SortedDictionary<string, SortedSet<Student>> allStudents)
        {
            foreach (var item in allStudents)
            {
                Console.WriteLine("{0} Course -> {1}", item.Key, string.Format(string.Join(", ", item.Value)));
            }
        }

        private static SortedDictionary<string, SortedSet<Student>> ReadDataFromFile()
        {
            var result = new SortedDictionary<string, SortedSet<Student>>();

            using (var reader = new StreamReader("../../students.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var elements = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = elements[0].Trim();
                    string lastName = elements[1].Trim();
                    string course = elements[2].Trim();

                    if (!result.ContainsKey(course))
                    {
                        result[course] = new SortedSet<Student>();
                        var studentToAdd = new Student(firstName, lastName);
                        result[course].Add(studentToAdd);
                    }
                    else
                    {                        
                        var studentToAdd = new Student(firstName, lastName);
                        result[course].Add(studentToAdd);
                    }

                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}
