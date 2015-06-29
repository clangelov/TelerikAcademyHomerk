namespace Task02.HumanObjects
{
    // StyleCop settings: disabled: Documentation Rules
    public class Human
    {
        private const string MaleName = "The Boy";
        private const string FemaleName = "The Girl";

        public Human()
        {
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public static Human GenereateHumanByGivenAge(int age)
        {
            var person = new Human();

            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = MaleName;
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = FemaleName;
                person.Gender = Gender.Female;
            }

            return person;
        }
    }
}
