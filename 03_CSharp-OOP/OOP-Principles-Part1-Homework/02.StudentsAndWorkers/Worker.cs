namespace _02.StudentsAndWorkers
{
    using System;

    // Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay
    // and method MoneyPerHour() that returns money earned by hour by the worker.
    class Worker : Human
    {
        private int hoursPerWeek;
        private decimal weekSalary;

        public Worker(string firstName, string secondName, int hoursPerWeek, decimal weekSalary)
            : base(firstName, secondName)  // re-using the parent constructor
        {
            this.HoursPerWeek = hoursPerWeek;
            this.WeekSalary = weekSalary;
        }

        public int HoursPerWeek
        {
            get
            {
                return this.hoursPerWeek;
            }
            set
            {
                if (value < 16 || value > 40)
                {
                    throw new ArgumentOutOfRangeException("You can't work less than 16 hour per week and more than 40 hours");
                }
                this.hoursPerWeek = value;
            }
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 40)
                {
                    throw new ArgumentOutOfRangeException("You can't earn less than the minimum");
                }
                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.HoursPerWeek; // returns money earned by hour by the worker
        }
        // implementing the abstract method
        protected override string DisplayInfoAboutYourself()
        {
            return string.Format("The worker {0}, earns {1:C} per hour", this.LastName, this.MoneyPerHour());
        }
    }
}
