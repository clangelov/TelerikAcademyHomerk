namespace _02.StudentsAndWorkers
{
    using System;

    // Define abstract class Human with first name and last name.
    abstract class Human
    {
        private string firstName;
        private string lastName;

        // You can not create an instance of a abstract class, this constructor will only be re-used by the heirs
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (CheckForCorrectValue(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (CheckForCorrectValue(value))
                {
                    this.lastName = value;
                }
            }
        }

        // Creating an method to check the input data
        private bool CheckForCorrectValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("You can not assign empty value");
            }
            if (value.Length < 3 || value.Length > 15)
            {
                throw new ArgumentOutOfRangeException("Your name is too short or too long");
            }

            return true;
        }

        // creating an abstract method to be implemented later
        protected abstract string DisplayInfoAboutYourself();

        // the abstract method can be accessed only via .ToString() method of the parent
        public override string ToString()
        {
            return this.DisplayInfoAboutYourself();
        }
    }
}
