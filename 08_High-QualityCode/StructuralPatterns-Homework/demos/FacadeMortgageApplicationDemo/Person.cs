namespace FacadeMortgageApplicationDemo
{
    using System;

    public class Person
    {
        public Person(string name, decimal monthlyIncome)
        {
            this.Name = name;
            this.MonthlyIncome = monthlyIncome;
        }

        public string Name { get; set; }

        public decimal MonthlyIncome { get; set; }
    }
}
